using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Good
{
    string name;

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }
}
public class Trade
{
    ShopScript shop;
    int step;
    float startPrice;
    Traidor T;
    float currentPrice;
   public float LastShopPrice;
    public ShopScript Shop
    {
        get
        {
            return shop;
        }

        set
        {
            shop = value;
        }
    }

    public int Step
    {
        get
        {
            return step;
        }

        set
        {
            step = value;
        }
    }

    public float StartPrice
    {
        get
        {
            return startPrice;
        }

        set
        {
            startPrice = value;
        }
    }

    public Traidor Tr
    {
        get
        {
            return T;
        }

        set
        {
            T = value;
        }
    }

    public float CurrentPrice
    {
        get
        {
            return currentPrice;
        }

        set
        {
            currentPrice = value;
        }
    }

    public void Accept()
    {
        Shop.TradeAcept(currentPrice);
    }
    public void Denial()
    {
        Shop.TradeDenial();
    }
    public void SetPrice(float price)
    {
        
        currentPrice = price;
        shop.TradeNewPrice(price);
    }
    public void ShopSetPrice(float price)
    {
        LastShopPrice = price;
        currentPrice = price;
        T.NewPrice(price);
    }
    public void Ultimatum(float price)
    {
        T.TakeUltimatum(price);
    }

}
public class ShopScript : MonoBehaviour {
    public float money;
    public Button[] ActionButtons;
    public delegate void TradeEndDlg();
    public event TradeEndDlg TradeEnd; 
    public float startprice;
    public int botlecount;
    public Text t;
    public Text t2;
    public Trade CurrentTrade;
    public Traidor Client;

    public void EndTrade()
    {
        DisableButtons();
        Client.GoAway();
        CurrentTrade = null;
        if (TradeEnd != null)
            TradeEnd.Invoke();
    }
    public void Accept()
    {
        t2.text = "Он согласился";
        t.text = "Вы согласились";
        Client.Buy = true;
        money += CurrentTrade.CurrentPrice;
        botlecount--;
        EndTrade();
    }
  public  void TradeAcept(float price)
    {
        t2.text = "Он согласился";
        money += price;
        botlecount--;
        EndTrade();

    }
    public void TradeNewPrice(float price)
    {
        t2.text = "ОН: Может договоримся за "+price.ToString()+"?";
    }
    public void SetNewPrice()
    {
        t.text ="ВЫ: Нет, давайте "+(CurrentTrade.CurrentPrice + (CurrentTrade.LastShopPrice - CurrentTrade.CurrentPrice) / 2).ToString()+".";

        CurrentTrade.ShopSetPrice(CurrentTrade.CurrentPrice+ (CurrentTrade.LastShopPrice-CurrentTrade.CurrentPrice)/2);
     }
   public void TradeDenial()
    {
        t2.text = "Он отказался";
        EndTrade();
    }
    public void DisableButtons()
    {
        foreach (var b in ActionButtons)
        {
            b.interactable = false;
        }
    }
    public void SetPrice(float price)
    {
        startprice = price;
    }
    public void ActivateButtons()
    {
        foreach (var b in ActionButtons)
        {
            b.interactable = true;
        }
    }
    public void SetUltimatum()
    {
        CurrentTrade.Ultimatum(CurrentTrade.LastShopPrice);
        t.text = "ВЫ:Или "+ CurrentTrade.LastShopPrice.ToString()+" или никак.";
    }
	// Use this for initialization
	void Start () {
        DisableButtons();
	}
    public void NewTraid()
    {
        CurrentTrade = new Trade();
        CurrentTrade.Shop = this;
        CurrentTrade.Tr = Client;
        Client.CurrentTrade = CurrentTrade;
        t.text = "ВЫ:Выпивка стоит " + startprice.ToString() + ".";
        CurrentTrade.ShopSetPrice(startprice);
        ActivateButtons();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
