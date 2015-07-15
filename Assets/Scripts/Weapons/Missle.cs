using UnityEngine;
using System.Collections;

public class Missle : MonoBehaviour {

    private Projectile stats;
	// Use this for initialization
	void Start () {
        //stats = projectile.GetComponent<Projectile>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
          // GameObject clone = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
          // clone.rigidbody.velocity = transform.TransformDirection(new Vector3(0, 0, stats.Speed));
          // Destroy(clone, 1.5f);
        }
	}
}
