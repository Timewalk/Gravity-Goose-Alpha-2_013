using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInput : MonoBehaviour {

	public float speed = 1.0f;
	public GameObject rayCastTargetPlane = null;
	public GameObject rayCastPositionPlane = null;

	private Vector3 positionOffset = Vector3.zero;
    private float rotationOffset = 0.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit _hitPositionPlane;
		RaycastHit _hitTargetPlane;
		Ray _ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Physics.Raycast (_ray, out _hitTargetPlane, 200.0f, 1 << 8);
		Physics.Raycast (_ray, out _hitPositionPlane, 200.0f, 1 << 9);

		Vector3 _lookAtPoint = (_hitTargetPlane.point - transform.position).normalized;
		Vector3 _moveToPoint = _hitPositionPlane.point;

		positionOffset = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
            positionOffset = positionOffset + Camera.main.transform.right * -10.0f;
		if (Input.GetKey (KeyCode.D))
            positionOffset = positionOffset + Camera.main.transform.right * 10.0f;
		if (Input.GetKey (KeyCode.W))
            positionOffset = positionOffset + Camera.main.transform.up * 10.0f;
		if (Input.GetKey (KeyCode.S))
            positionOffset = positionOffset + Camera.main.transform.up * -10.0f;
        
        if (Input.GetKey(KeyCode.Q))
            rotationOffset += 180 * Time.deltaTime;
        else if (Input.GetKey(KeyCode.E))
            rotationOffset -= 180 * Time.deltaTime;
        else
            if (rotationOffset > 2.0f || rotationOffset < -2.0f)
                if (rotationOffset < 30 && rotationOffset > -30)
                    rotationOffset -= (rotationOffset / Mathf.Abs(rotationOffset)) * 180 * Time.deltaTime;
                else
                    rotationOffset += (rotationOffset / Mathf.Abs(rotationOffset)) * 180 * Time.deltaTime;

        if (Input.GetKey(KeyCode.Escape))
            Application.LoadLevel("Buy_Menu");

        rotationOffset = rotationOffset % 360;
        Quaternion _roll = Quaternion.AngleAxis(rotationOffset, Vector3.forward);

		transform.position = Vector3.MoveTowards (transform.position, _moveToPoint + positionOffset, Time.deltaTime * speed);
		transform.rotation = Quaternion.LookRotation (_lookAtPoint) * _roll;

		Debug.DrawLine (Camera.main.transform.position, _hitTargetPlane.point, Color.white);
		//Debug.DrawLine (Camera.main.transform.position, transform.position, Color.white);

        StaticInformation.raycastTargetPoint = _hitTargetPlane.point;
        StaticInformation.raycastPositionPoint = _hitPositionPlane.point;
        StaticInformation.playerShipTransform = transform;
        

	}
}
