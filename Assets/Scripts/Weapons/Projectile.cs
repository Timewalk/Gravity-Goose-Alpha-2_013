using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public enum Type
    {
        Normal, Beam, Homing
    }

    public float Speed = 1;
    public float Damage = 1;
    public float Capacity = 1;
    public float LifeSpan = 1;
    public float LockTime = 1;
    public Type WeaponType;
    public LayerMask Targets;

    
    
    
    void Start()
    {
        
    }

    void LateUpdate()
    {
       switch(WeaponType)
       {
           case Type.Normal:
               break;
           case Type.Beam:
               break;
           case Type.Homing:
               break;
       }
    }

    void OnTriggerEnter(Collider target)
    {

        if (target.tag == "Enemy")
        {
            Debug.Log("HIT");
            Destroy(this.gameObject);
        }

     
    }
}
