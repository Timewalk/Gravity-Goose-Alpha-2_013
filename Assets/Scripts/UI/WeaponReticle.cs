using UnityEngine;
using System.Collections;

public class WeaponReticle : MonoBehaviour {

    public GameObject WeaponPrefab;
    private GameObject WeaponSprite;

    public LayerMask ignorLayer_1;
    public LayerMask ignorLayer_2;
    public LayerMask ignorLayer_3;
    public LayerMask ignorLayer_4;
    public LayerMask ignorLayer_5;

    private LayerMask ignorLayers;

	// Use this for initialization
	void Start () {
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

        WeaponSprite = (GameObject)Instantiate(WeaponPrefab);
        ignorLayers = ~ignorLayers;

	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit _hit;
        Ray _ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(_ray, out _hit, 200.0f, ignorLayers))
        {
            WeaponSprite.transform.position = _hit.point;
            WeaponSprite.transform.rotation = transform.rotation;
        }
	}
}
