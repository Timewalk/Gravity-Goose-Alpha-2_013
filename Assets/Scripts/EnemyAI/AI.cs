using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI : MonoBehaviour {

    public float movementSpeed = 1.0f;

    private GameObject target;
    private GameObject dumpSpawn;
    private GameObject dumpEnemyWaypoints;
    private List<GameObject> enemyWaypoits;
    private List<GameObject> spawnLocations;
    private GameObject waypoint;
    private GameplayObjectInfo info;

	// Use this for initialization
	void Start () {

        // Find a better way than tag whoreing
        dumpEnemyWaypoints = GameObject.FindGameObjectWithTag("EnemyWaypoints");
        target = GameObject.FindGameObjectWithTag("Target");
        dumpSpawn = GameObject.FindGameObjectWithTag("EnemySpawner");
        info = GetComponent<GameplayObjectInfo>();
        waypoint = new GameObject();

        enemyWaypoits = new List<GameObject>();
        foreach (Transform obj in dumpEnemyWaypoints.transform)
            enemyWaypoits.Add(obj.gameObject);


        spawnLocations = new List<GameObject>();
        foreach (Transform obj in dumpSpawn.transform)
            spawnLocations.Add(obj.gameObject);

        int rand = Random.Range(0, 3);

        transform.position = spawnLocations[rand].transform.position;

        int idx = Random.Range(0, enemyWaypoits.Count - 1);
        waypoint = enemyWaypoits[idx];

	}
	
	// Update is called once per frame
	void Update () 
    {
        if (waypoint.transform.position == transform.position)
            waypoint = enemyWaypoits[Random.Range(0, enemyWaypoits.Count - 1)];

        transform.parent = waypoint.transform;

        transform.position = Vector3.MoveTowards(transform.position, waypoint.transform.position, movementSpeed * Time.deltaTime);

        transform.rotation = Quaternion.LookRotation(Vector3.Slerp(transform.forward, 
            target.transform.position - transform.position, Time.deltaTime * movementSpeed / 2));

	}

    void OnTriggerEnter(Collider projectile)
    {
        if (projectile.CompareTag("Enemy"))
            return;

        info.currentShield -= projectile.GetComponent<Projectile>().Damage;

        if (info.currentShield < 0)
            info.currentHealth -= projectile.GetComponent<Projectile>().Damage;

        if (info.currentHealth <= 0)
        {
            StaticInformation.cash += 126;
            StaticInformation.currNumEnemies -= 1;
            Destroy(gameObject);     
        }
    }

}
