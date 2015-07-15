using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetTargetHealth : MonoBehaviour {

    private GameObject target;
    private GameplayObjectInfo targetInfo;

	// Use this for initialization
	void Start () 
    {
        target = new GameObject();
        targetInfo = new GameplayObjectInfo();
	}
	
	// Update is called once per frame
	void Update ()
    {
        target = StaticInformation.playersTarget;

        if (StaticInformation.playersLock != null)
            target = StaticInformation.playersLock;

        targetInfo = target.GetComponent<GameplayObjectInfo>();
        if (targetInfo)
        {
            GetComponent<Image>().fillAmount = targetInfo.currentHealth / targetInfo.maxHealth;
        }
        else
            GetComponent<Image>().fillAmount = 0.0f;
	}

}
