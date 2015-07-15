using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuManager : MonoBehaviour {

    Inventory CurrentInventory;
    public GameObject BlockWeapon;
    public GameObject BlockShield;
    public GameObject BlockArmor;
    [HideInInspector]
    public ButtonInfo bi_;
   
	// Use this for initialization
	void Awake () {
        PlayerPrefs.DeleteAll();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
	
	}

    public void ShowInventory(Inventory inv)
    {
        if (CurrentInventory != null)
            CurrentInventory.IsOpen = false;

        CurrentInventory = inv;
        if (CurrentInventory != null)
        {
            if (CurrentInventory.name == "WeaponInventory")
            {
                BlockWeapon.SetActive(false);
                BlockShield.SetActive(true);
                BlockArmor.SetActive(true);
            }
            if (CurrentInventory.name == "ShieldInventory")
            {
                BlockWeapon.SetActive(true);
                BlockShield.SetActive(false);
                BlockArmor.SetActive(true);
            }
            if (CurrentInventory.name == "ProbesInventory")
            {
                BlockWeapon.SetActive(true);
                BlockShield.SetActive(true);
                BlockArmor.SetActive(true);
            }
            if (CurrentInventory.name == "ArmorInventory")
            {
                BlockWeapon.SetActive(true);
                BlockShield.SetActive(true);
                BlockArmor.SetActive(false);
            }
        }
        CurrentInventory.IsOpen = true;
    }


    public void LoadScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }


    
}
