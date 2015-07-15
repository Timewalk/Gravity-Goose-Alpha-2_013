using UnityEngine;
using System.Collections;

public class TargetLock : MonoBehaviour {

	// Use this for initialization
	void Start () {

        transform.parent = StaticInformation.playersLock.transform;
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = StaticInformation.playersLock.transform.position;
        transform.rotation = Camera.main.transform.rotation;    
	}
}
