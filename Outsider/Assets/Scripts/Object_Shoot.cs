using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Shoot : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveforce = 0f;
    private Rigidbody rigidbody;
    public GameObject projectile;
    public Transform gun;
    public float fireRate = 0f;
    public float projectileForce = 0f;
    private float fireRateTimeStamp = 0f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal")*moveforce;
        float Vertical = Input.GetAxisRaw("Vertical")*moveforce;
        rigidbody.velocity = new Vector3(Horizontal,Vertical,0);

        if(Input.GetKey(KeyCode.E)){
            if(Time.time > fireRateTimeStamp){
                GameObject go = (GameObject)Instantiate(projectile,gun.position, gun.rotation);
                go.GetComponent<Rigidbody>().AddForce(gun.forward * projectileForce);
                fireRateTimeStamp = Time.time + fireRate;
            }
        }
    }
}
