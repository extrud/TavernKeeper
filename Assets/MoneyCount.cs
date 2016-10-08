using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MoneyCount : MonoBehaviour
{

    Text t;
    public ShopScript ss;
    // Use this for initialization
    void Start()
    {
        t = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = ss.money.ToString();
    }
}
