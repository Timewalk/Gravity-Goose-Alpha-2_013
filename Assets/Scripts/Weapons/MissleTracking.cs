using UnityEngine;
using System.Collections;

public class MissleTracking : Projectile {

    private GameObject target;
    private float speed;


    void Start () {
        target = StaticInformation.playersLock;
        transform.parent = target.transform;
        speed = 1;

        
	}
	
    void FixedUpdate () {
        speed += Time.deltaTime * 10;
       
            if (transform.position != target.transform.position)
            {
                Vector3 _target = (target.transform.position - transform.position).normalized;
                transform.rotation = Quaternion.LookRotation(_target);
                transform.position = Vector3.MoveTowards(transform.position, transform.forward * 100, Time.deltaTime * speed);
            }
        
	}

}
