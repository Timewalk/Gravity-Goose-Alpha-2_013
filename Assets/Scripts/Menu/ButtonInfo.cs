using UnityEngine;
using System.Collections;

public class ButtonInfo : MonoBehaviour {

    public string FlavorName;
    public string PrefabName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnDrag (GameObject obj)
    {
        obj.GetComponent<MenuManager>().bi_ = transform.GetComponent<ButtonInfo>();

    }

    
}
