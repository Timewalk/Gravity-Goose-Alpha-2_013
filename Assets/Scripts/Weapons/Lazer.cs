using UnityEngine;
using System.Collections;

public class Lazer : MonoBehaviour {

    //public GameObject weapon;
    //private GameObject _weapon;

    //private LayerMask ignore;

	// Use this for initialization
	void Start () {
        //ignore = 1 << 9;
        
        
	}
	
	// Update is called once per frame
	void LateUpdate () {
        
        //if (_weapon == null)
         // _weapon = (GameObject)GameObject.Instantiate(Resources.Load("Lazer"));
        
        if (Input.GetButton("Fire1"))
        {

            //LineRenderer _lr = _weapon.GetComponent<LineRenderer>();
            //_lr.SetPosition(0, transform.position);

            //RaycastHit hit;
            Ray _ray = new Ray(transform.position, transform.forward * 50.0f);
            Debug.DrawRay(transform.position, transform.forward * 50.0f, Color.blue);

            LineRenderer _lr = transform.gameObject.AddComponent<LineRenderer>();
            _lr.useWorldSpace = true;
            _lr.SetPosition(0, transform.position);
            Vector3 endPoint = transform.position + transform.forward*50.0f;
            _lr.SetPosition(1, endPoint);


            //if (Physics.Raycast(_ray, out hit, 500.0f))
            //{
            //    _lr.SetPosition(1, hit.point);
            //}
            //else
            //    _lr.SetPosition(1, transform.forward * 50.0f);

           // Debug.DrawRay()
            //if (Physics.Raycast(transform.position, transform.forward * 100.0f, out hit))
            //    _lr.SetPosition(1, hit.point);
            //else
               // _lr.SetPosition(1, StaticInformation.raycastTargetPoint);
            Destroy(_lr, .01f);
        }
        //else
        //    Destroy();
        

	}
}
