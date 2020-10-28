using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Collision : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Self;
    public GameObject Destroy;
    public GameObject SpawnOnCollide;
    void OnCollisionEnter (Collision collisionInfo){
        GameObject go = (GameObject)Instantiate(SpawnOnCollide,Self.position, Self.rotation);
        Destroy(Destroy);
    }

}
