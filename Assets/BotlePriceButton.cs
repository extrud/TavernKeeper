using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BotlePriceButton : MonoBehaviour {
    public GameControl gc;
    Text t;
	// Use this for initialization
	void Start () {
        t = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        t.text = "Купить выпивку ("+gc.BotlePrice.ToString()+")";
	}
}
