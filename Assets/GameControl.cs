using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameControl : MonoBehaviour {
    public Text Time;
    public Text Taxes;
    public RectTransform panEndDay;
    public RectTransform panGameOver;
    public ShopScript ss;
    public int seconds;
    public GameObject CLientPref;
    public int day;
    public int ClientsCount;
    public int BotlePrice;
    public float ReclamPrice;
    public float PRPrice;
    public float ElitPrice;
    public int Reclamlvl;
    public int PRlvl;
    public int Elitlvl;
    Coroutine TimerC;
    Traidor t;
    // Use this for initialization
	void Start () {
        
        ss.TradeEnd += OnClientEnd;
        NewGame();
	}
	
	// Update is called once per frame
	void Update () {
	}
    IEnumerator Timer()
    {
        while (seconds > 0)
        {
            seconds--;
            Time.text = seconds.ToString();
            yield return new WaitForSeconds(1);
        }
     
    }
    void EndDay()
    {
        if(TimerC!=null)
        StopCoroutine(TimerC);
        day++;
        int taxes = Random.Range(3, 8) * day + Random.Range(10, 20);
        Taxes.text = "На уплату налогов ушло" + taxes.ToString();
        ss.money -= taxes;
        if (ss.money < 0)
        {
            GameOver();
        }
        BotlePrice = 10 + day * 2 + Random.Range((int)0,(int)day * 10);
        if (ss.money < BotlePrice && ss.botlecount<=0)
        {
            GameOver();
        }
        panEndDay.gameObject.SetActive(true);
    }
    void GameOver()
    {
        panEndDay.gameObject.SetActive(false);
        panGameOver.gameObject.SetActive(true);
    }
    public void NewGame()
    {

        panEndDay.gameObject.SetActive(false);
        panGameOver.gameObject.SetActive(false);
        PRlvl = 0;
        Elitlvl = 0;
        Reclamlvl = 0;
        ss.money = 150;
        ss.botlecount = 12;
        day = 1;
        EndDay();
    }
    public void ByBotle()
    {
        if (ss.money > BotlePrice)
        {
            ss.money -= BotlePrice;
            ss.botlecount++;
        }
    }
    public void NewDay()
    {
        panEndDay.gameObject.SetActive(false);
        ClientsCount = 8 + day * Random.Range(0, 3) + Random.Range(0, 15);
        seconds = 40;
        StartCoroutine(Timer());
        NewClient();
    }
    void OnClientEnd()
    {
        NewClient();
    }
    public void NewClient()
    {
        ClientsCount--;
        if (ClientsCount <= 0)
        {
            EndDay();
            return;
        }
        if (ss.botlecount <= 0)
        {
            EndDay();
            return;
        }
        if (seconds <= 0)
        {
            EndDay();
            return;
        }
        t = ((GameObject)Instantiate(CLientPref, new Vector3(16f, 3.9f),CLientPref.transform.rotation)).GetComponent<Traidor>();
        t.Money = Random.Range(10, 70 + day*10);
        t.Pliability = Random.Range(0.1f, 0.9f);
        t.MinP =(int) (t.Money * (1 - t.Pliability) + Random.Range(-20, 20)); 
        t.MaxP = (int)(t.Money - t.Money * (1 - t.Pliability) + Random.Range(-20,20));
        if (t.MaxP > t.Money)
        {
            t.MaxP = (int)t.Money;
        }
        if (t.MaxP < t.MinP)
        {
            t.MaxP = t.MinP;
        }
        t.patience = Random.Range(1, 8);
        t.OnPos += ClientOnPos;
    }
    public void ClientOnPos()
    {
        ss.Client = t;
        ss.NewTraid();
    }
}
