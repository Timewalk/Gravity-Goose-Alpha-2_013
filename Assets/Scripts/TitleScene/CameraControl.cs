using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public int playersCurrentWaypoint;
    public GameObject lookAtPoint;
    public GameObject railCart;
    public Animator anim;
    public float speed = 1.0f;

    private AudioSource audio;

	// Use this for initialization
	void Start () {
        playersCurrentWaypoint = railCart.GetComponent<WaypointSystem>().currentWP;
        audio = Camera.main.transform.gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        playersCurrentWaypoint = railCart.GetComponent<WaypointSystem>().currentWP;
        Debug.Log(playersCurrentWaypoint);

        if (playersCurrentWaypoint == 1)
        {


        }
        if (playersCurrentWaypoint > 1)
        {
            Camera.main.transform.parent = transform;

            if (Camera.main.transform.position != transform.position)
                Camera.main.transform.position = Vector3.Slerp(Camera.main.transform.position, transform.position, Time.deltaTime * speed);

            Vector3 _look = (Vector3.Slerp(Camera.main.transform.forward, lookAtPoint.transform.position, Time.deltaTime * speed )).normalized;

            Camera.main.transform.rotation = Quaternion.LookRotation(_look);

            if (!audio.isPlaying)
            {
                audio.Play();
                anim.SetBool("IsOpen", true);
            }
            if (audio.volume != 1.0f)
                audio.volume = Mathf.Lerp(audio.volume, 1.0f, Time.deltaTime / 10.0f);
        }
	}

    public void LoadShop ()
    {
        Application.LoadLevel("Buy_Menu");
    }
}
