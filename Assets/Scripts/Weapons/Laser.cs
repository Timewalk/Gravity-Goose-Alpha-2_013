using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{

    private string KeyBind;
    private bool applyKeyBind = true;
    LineRenderer lr;
    LayerMask ignoreLayer;
    // Use this for initialization
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        //ignoreLayer = 1 << 9;
        //ignoreLayer |= 1 << 8;
        //ignoreLayer |= 1 << 1;
        //ignoreLayer = ~ignoreLayer;
        ignoreLayer = 1 << 1;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 offset = transform.parent.transform.position;

        SetKeyBind();
        if (lr != null)
        {
            lr.SetPosition(0, offset + transform.position);
            lr.SetPosition(1, offset + transform.position);
            if (Input.GetButton(KeyBind))
            {
                //Debug.Log(transform.position.ToString());
                //Debug.Log(transform.parent.transform.position.ToString());
                Ray _ray = new Ray(offset + transform.position, offset + transform.forward * 200.0f);
                RaycastHit _hit;
                if (Physics.Raycast(_ray, out _hit, 200.0f, ~ignoreLayer))
                {
                    //Debug.Log("HIT");
                    lr.SetPosition(1, _hit.point);
                }
                else
                {
                    //Debug.Log("MISS");
                    lr.SetPosition(1, StaticInformation.raycastTargetPoint);
                }

            }
        }
        
    }

    void SetKeyBind()
    {
        if (applyKeyBind)
        {
            if (transform.parent)
            {
                if (transform.parent.transform.parent.name.ToString() == "Actor")
                {
                    if (transform.parent.name.ToString() == "Anchor1")
                        KeyBind = "Fire1";
                    else if (transform.parent.name.ToString() == "Anchor2")
                        KeyBind = "Fire2";
                    else if (gameObject.name == PlayerPrefs.GetString("Extra1") + "(Clone)")
                        KeyBind = "1";
                    else if (gameObject.name == PlayerPrefs.GetString("Extra2") + "(Clone)")
                        KeyBind = "2";
                }

                Debug.Log("1. keybind = " + KeyBind);
                //Debug.Log("2. ");

                applyKeyBind = false;

            }
        }
    }
}
