using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TargetReticle : MonoBehaviour
{

    public GameObject TargetLockPrefab;

    public LayerMask ignorLayer_1;
    public LayerMask ignorLayer_2;
    public LayerMask ignorLayer_3;
    public LayerMask ignorLayer_4;
    public LayerMask ignorLayer_5;

    private LayerMask ignorLayers;

    private GameObject currTarget;
    private GameObject lockMarker;
    private float lockTimer = 0.0f;
    private bool targetLocked = false;

    // Use this for initialization
    void Start()
    {
        if (ignorLayer_1 != null)
            ignorLayers |= ignorLayer_1;
        if (ignorLayer_2 != null)
            ignorLayers |= ignorLayer_2;
        if (ignorLayer_3 != null)
            ignorLayers |= ignorLayer_3;
        if (ignorLayer_4 != null)
            ignorLayers |= ignorLayer_4;
        if (ignorLayer_5 != null)
            ignorLayers |= ignorLayer_5;

        ignorLayers = ~ignorLayers;
        Cursor.visible = false;
    }

    // Update is called once per frame

    void Update()
    {
        RaycastHit _hit;
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, 200.0f, ignorLayers))
        {
            transform.position = _hit.point;
            StaticInformation.playersTarget = _hit.transform.gameObject;
            GameObject _target = _hit.transform.gameObject;

            if (_target.Equals(currTarget))
                lockTimer += Time.deltaTime;
            else if (_target.tag == "Enemy")
            {
                currTarget = _target;
                
                lockTimer = 0.0f;
            }
            else
                lockTimer = 0.0f;

        }
        else
            transform.position = StaticInformation.raycastTargetPoint;


        if (lockTimer > 2.0f && targetLocked == false)
        {
            StaticInformation.playersLock = currTarget.gameObject;

            if (lockMarker != null)
                Destroy(lockMarker);
            lockMarker = (GameObject)Instantiate(TargetLockPrefab);
            //Debug.Log("True");
            targetLocked = true;
        }
        else if (lockTimer < 2.0f)
        {
            targetLocked = false;

        }

        transform.rotation = Camera.main.transform.rotation;


    }
}
