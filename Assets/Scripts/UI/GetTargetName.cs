using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetTargetName : MonoBehaviour {

    private GameObject target;
    private GameplayObjectInfo targetInfo;

	// Use this for initialization
	void Start () 
    {
        //target = new GameObject();
        //targetInfo = new GameplayObjectInfo();
	
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
            GetComponent<Text>().text = targetInfo.name;
            //Debug.Log("True");

        }
        else
            GetComponent<Text>().text = " ";
	}
}
