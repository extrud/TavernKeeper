using UnityEngine;
using System.Collections;

public class Traidor : MonoBehaviour {
    public Trade CurrentTrade;
    public Sprite[] HeadSprites;
    public SpriteRenderer HeadSR;
    public SpriteRenderer hendSR;
    public SpriteRenderer FullHand;
    public float MinP;
    public float lastprice;
    public float MaxP;
    public int patience;
    public int curpatience =0;
    public delegate void OnPosDlg();
    public event OnPosDlg OnPos;
    public bool Buy;
    public float average  
    {
        get { return MinP + (MaxP - MinP); }
    }
    public float Pliability; // 0.0 - 1.0
    public float Money;
    public bool Decide(float price,bool ult =false)
    {
      
        float chance;
        if (price - lastprice < 1)
        {
            return true;
        }
        if (price < MinP)
            return true;
        if (price > Money)
            return false;
        if (price > MaxP)
        {
           
            if (ult)
            {
                chance = Pliability - ((price - MaxP) / MaxP);
                Debug.Log(chance.ToString());
                Debug.Log(chance);
                if (Random.Range(0f, 1f) < chance)
                {
                   
                    return true;
                }
                else
                    return false;
                    }
            else
                return false;
        }

        chance = Pliability + ((MaxP - price)/ (MaxP - MinP));
        Debug.Log(chance.ToString());
        if (Random.Range(0f, 1f) < chance)
        {
           
            return true;
             
        }
        else
            return false;
    }
    public void NewPrice(float price)
    {
        curpatience++;
        if (curpatience >= patience)
        {
            CurrentTrade.Denial();
            return;
        }
        if (Decide(price))
        {
            Buy = true;
            CurrentTrade.Accept();
            return;
        }
        else
        {
            float newprice;
            if (price > MaxP)
            {
                newprice = MaxP - Random.Range(0f, MinP+((MaxP - MinP) * (1 - Pliability)));
                if (newprice < lastprice)
                    newprice = lastprice;
                lastprice = newprice;
                CurrentTrade.SetPrice(newprice);
                
            }
            else
            {
                newprice = price - Random.Range(0f, (price-lastprice) * (1 - Pliability));
                if (newprice < lastprice)
                    newprice = lastprice;
                lastprice = newprice;
                CurrentTrade.SetPrice(newprice);
              
            }
            
        }
    }
    public void TakeUltimatum(float price)
    {
        if (Decide(price, true))
        {
            Buy = true;
            CurrentTrade.Accept();
        }
        else
        {
            CurrentTrade.Denial();
        }
    }
    public IEnumerator GoToCenterCur()
    {
        while (transform.position.x > 0)
        {
            transform.Translate(Vector2.left * 10 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        if (OnPos != null)
        {
            OnPos();
        }

    }
    IEnumerator GoAwayCur()
    {
        if (Buy)
        {
            hendSR.enabled = false;
            FullHand.enabled = true;
        }
        while (transform.position.x > -16)
        {
            transform.Translate(Vector2.left * 10 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        Destroy(this.gameObject);
    }
    public void GoAway()
    {
        StartCoroutine(GoAwayCur());
    }
	// Use this for initialization
	void Start () {
        HeadSR.sprite = HeadSprites[Random.Range(0, HeadSprites.Length)];
        StartCoroutine(GoToCenterCur());
	}
	
	// Update is called once per frame
	void Update () {
       
    }
}
