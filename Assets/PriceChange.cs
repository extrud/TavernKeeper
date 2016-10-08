using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PriceChange : MonoBehaviour {
    public ShopScript ss;
    public Text text;
    Slider s;
	// Use this for initialization
	void Start () {
        s = GetComponent<Slider>();
        s.onValueChanged.AddListener(delegate { OnValueChenge(); });
    }
    void OnValueChenge()
    {
        text.text = s.value.ToString();
        ss.SetPrice(s.value);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
