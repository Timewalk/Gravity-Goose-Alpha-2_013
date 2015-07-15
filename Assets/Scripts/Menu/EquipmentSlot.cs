using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EquipmentSlot : MonoBehaviour {

    public string FlavorText;
    public string PrefabName;
    public Text Display;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnDrop(GameObject obj)
    {
        FlavorText = obj.GetComponent<MenuManager>().bi_.FlavorName;
        PrefabName = obj.GetComponent<MenuManager>().bi_.PrefabName;
        PlayerPrefs.SetString(gameObject.name, PrefabName);
        Display.text = FlavorText;

    }
}
