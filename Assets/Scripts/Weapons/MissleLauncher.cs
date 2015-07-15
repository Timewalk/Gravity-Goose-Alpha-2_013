using UnityEngine;
using System.Collections;

public class MissleLauncher : Equipment {

    private GameObject Missle;


    private GameObject UIBtn;
    private string Name;
    //private string KeyBind;
    private float CDMax;
    private float CDCurr;



	// Use this for initialization
	void Start () {
        UIBtn = (GameObject)Instantiate(Resources.Load("UI/CDBtn"));
        UIBtn.transform.parent = GameObject.FindGameObjectWithTag("CoolDownBar").transform;
       

	}
	
	// Update is called once per frame
	void LateUpdate () {
        Debug.Log("1. " + KeyBind);
        if(Input.GetButtonDown(KeyBind) && StaticInformation.playersLock != null)
        {
            Missle = (GameObject)Instantiate(Resources.Load("Equipment/Missle"));
            Missle.transform.position = transform.position;
        }
	}

    void OnGUI()
    {


    }

}
