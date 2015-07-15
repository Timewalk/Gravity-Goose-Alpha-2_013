using UnityEngine;
using System.Collections;

public class Equipment : MonoBehaviour {

    protected string KeyBind;
    protected Projectile stats;
    protected GameObject projectile;
    private bool applyKeyBind = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        SetKeyBind();
	}

    protected void SetKeyBind()
    {
        if (applyKeyBind)
        {
            if (transform.parent)
            {
                if (transform.parent.transform.parent.name.ToString() == "Actor")
                {
                    if (transform.parent.name.ToString() == "Anchor1")
                        KeyBind = "Fire1";
                    else if (transform.parent.name.ToString() == "Anchor2")
                        KeyBind = "Fire2";
                    else if (gameObject.name == PlayerPrefs.GetString("Extra1") + "(Clone)")
                        KeyBind = "1";
                    else if (gameObject.name == PlayerPrefs.GetString("Extra2") + "(Clone)")
                        KeyBind = "2";
                }



                applyKeyBind = false;

            }
        }
    }
}
