using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class WaypointSystem : MonoBehaviour {

    
    private List<GameObject> waypoints;
    private float _adjustRoll = 1.0f;

    public GameObject dump;
    public float speed;
    public float rotationSpeed;
    public float accuracy;
    public int currentWP = 0;


	void Start () {
        waypoints = new List<GameObject>();
        foreach (Transform x in dump.transform)
            waypoints.Add(x.gameObject);

        _adjustRoll = 1.0f;
	}
	
   void Update () {
       if (waypoints.Count == 0) return;
       if (Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < accuracy)
       {
           currentWP++;
           if (currentWP >= waypoints.Count)

               currentWP = 0;
       }

       
       Vector3 _nextPoint = waypoints[currentWP].transform.position - transform.position;
       Vector3 _Look = (Vector3.Slerp(transform.forward, _nextPoint, Time.deltaTime * rotationSpeed / 10)).normalized;


       if (_nextPoint.x > 2.0f)
           _adjustRoll -= 1.0f * Time.deltaTime * rotationSpeed;
       else if (_nextPoint.x < -2.0f)
           _adjustRoll += 1.0f * Time.deltaTime * rotationSpeed;
       else if (_adjustRoll != 0.0f)
           _adjustRoll -= (_adjustRoll / Mathf.Abs(_adjustRoll)) * Time.deltaTime * rotationSpeed;

       Quaternion _roll = Quaternion.AngleAxis(_adjustRoll, Vector3.forward);

       transform.rotation = Quaternion.LookRotation(_Look) * _roll;
       transform.position = transform.position + (transform.forward * speed / 10);

       StaticInformation.playersCurrentWaypoint = currentWP;
   }
}
