using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Collision : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Self;
    public GameObject Destroy;
    public GameObject SpawnOnCollide;
    public float Damage;
    void OnCollisionEnter (Collision collisionInfo){
        var health = collisionInfo.collider.GetComponent<Object_Health>();
        if(health!=null){
            health.TakeDamage(Damage);
        }
        GameObject go = (GameObject)Instantiate(SpawnOnCollide,Self.position, Self.rotation);
        Destroy(Destroy);
    }

}
