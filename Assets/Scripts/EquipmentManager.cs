using UnityEngine;
using System.Collections;

public class EquipmentManager : MonoBehaviour
{

    private GameObject Weapon1;
    private GameObject Weapon2;
    private GameObject Extra1;
    private GameObject Extra2;
    private GameObject Shield1;
    private GameObject Shield2;
    private GameObject Armor;
    public GameObject anchor1;
    public GameObject anchor2;
    public GameObject anchor3;
    public GameObject anchor4;

    public bool parent = false;
    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetString("Weapon1") != "")
            Weapon1 = (GameObject)Instantiate(Resources.Load("Equipment/" + PlayerPrefs.GetString("Weapon1")));
        if (PlayerPrefs.GetString("Weapon2") != "")
            Weapon2 = (GameObject)Instantiate(Resources.Load("Equipment/" + PlayerPrefs.GetString("Weapon2")));
        if (PlayerPrefs.GetString("Extra1") != "")
            Extra1 = (GameObject)Instantiate(Resources.Load("Equipment/" + PlayerPrefs.GetString("Extra1")));
        if (PlayerPrefs.GetString("Extra2") != "")
            Extra2 = (GameObject)Instantiate(Resources.Load("Equipment/" + PlayerPrefs.GetString("Extra2")));
        if (PlayerPrefs.GetString("Shield1") != "")
            Shield1 = (GameObject)Instantiate(Resources.Load("Equipment/" + PlayerPrefs.GetString("Shield1")));
        if (PlayerPrefs.GetString("Shield2") != "")
            Shield2 = (GameObject)Instantiate(Resources.Load("Equipment/" + PlayerPrefs.GetString("Shield2")));
        if (PlayerPrefs.GetString("Armor") != "")
            Armor = (GameObject)Instantiate(Resources.Load("Equipment/" + PlayerPrefs.GetString("Armor")));


    }

    // Update is called once per frame
    void Update()
    {
        if (parent == false)
        {
            parent = true;
            if (Weapon1 != null)
            {
                Weapon1.transform.parent = anchor1.transform;
                Weapon1.transform.position = anchor1.transform.position;
                Weapon1.transform.rotation = anchor1.transform.rotation;
            }
            if (Weapon2 != null)
            {
                Weapon2.transform.parent = anchor2.transform;
                Weapon2.transform.position = anchor2.transform.position;
                Weapon2.transform.rotation = anchor2.transform.rotation;
            }
            if (Extra1 != null)
            {
                Extra1.transform.parent = anchor3.transform;
                Extra1.transform.position = anchor3.transform.position;
                Extra1.transform.rotation = anchor3.transform.rotation;
            }
            if (Extra2 != null)
            {
                Extra2.transform.parent = anchor4.transform;
                Extra2.transform.position = anchor4.transform.position;
                Extra2.transform.rotation = anchor4.transform.rotation;
            }

        }
    }
}
