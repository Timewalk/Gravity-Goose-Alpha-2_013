using UnityEngine;
using System.Collections;

public class PulseLauncher : Equipment {

	// Use this for initialization
	void Start () {
        
        projectile = (GameObject)Resources.Load("Equipment/Pulse");
        stats = projectile.GetComponent<Projectile>();

	}
	
	// Update is called once per frame
	void LateUpdate () {
        Debug.Log("2. " + KeyBind);
        if (Input.GetButton(KeyBind)) //testing must change to keybind
        {
            Rigidbody clone = (Rigidbody)Instantiate(projectile.GetComponent<Rigidbody>(), transform.position, transform.rotation);
            clone.velocity = transform.TransformDirection(new Vector3(0, 0, stats.Speed));
        }
	}
}
