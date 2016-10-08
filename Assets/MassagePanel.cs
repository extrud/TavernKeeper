using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class MassagePanel : MonoBehaviour {
    RectTransform panel;
    List<MessageBlock> MesageBlocks;
    public GameObject MesBoxPref;
    // Use this for initialization
	void Start () {
        AddMess("ololo");
	}
    void AddMess(string text)
    {
        GameObject newMessObject = (GameObject)Instantiate(MesBoxPref, new Vector3(174, -29, 0), MesBoxPref.transform.rotation);
        newMessObject.transform.SetParent(transform);
        newMessObject.transform.position = new Vector3(174, -29, 0);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
