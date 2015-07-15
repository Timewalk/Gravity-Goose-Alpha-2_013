using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetCash : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "$" + StaticInformation.cash.ToString();
	}
}
