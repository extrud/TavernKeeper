using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class KompromisInfo : MonoBehaviour {
    public ShopScript ss;
    public Text Text;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (ss.CurrentTrade != null)
            Text.text = "Компромис (" + (ss.CurrentTrade.CurrentPrice + (ss.CurrentTrade.LastShopPrice - ss.CurrentTrade.CurrentPrice) / 2).ToString() + ")";
        else
            Text.text = "Компромис";
    }
}
