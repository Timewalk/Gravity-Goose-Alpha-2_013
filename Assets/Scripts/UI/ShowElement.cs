using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShowElement : MonoBehaviour {

    private GameObject target;
    private GameplayObjectInfo targetInfo;
    private List<GameObject> children;


	void Start () 
    {
        target = new GameObject();
        targetInfo = new GameplayObjectInfo();

        children = new List<GameObject>();
        foreach (Transform obj in transform)
            children.Add(obj.gameObject);
	
	}
	
	void Update () 
    {
        target = StaticInformation.playersTarget;
        if (StaticInformation.playersLock != null)
            target = StaticInformation.playersLock;
        targetInfo = target.GetComponent<GameplayObjectInfo>();

        if (!targetInfo)
            foreach (GameObject obj in children)
                obj.SetActive(false);
        else
            foreach (GameObject obj in children)
                obj.SetActive(true);
	
        /// LOL I like when dumb ideas work...
	}
}
