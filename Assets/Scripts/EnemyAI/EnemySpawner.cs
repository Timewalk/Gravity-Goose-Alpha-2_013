using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public Object enemyPrefab;
    public int maxNumEnemies = 1;




	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (StaticInformation.currNumEnemies < maxNumEnemies)
        {
            GameObject _temp = (GameObject)Instantiate(enemyPrefab);
            StaticInformation.currNumEnemies++;
        }

	}
}
