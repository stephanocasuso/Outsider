using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour

{
  private CheckPointMaster cm;
  private Health health_amount;
  void Awake(){
     health_amount = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
  }
  void Start()
    {
      cm = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckPointMaster>();
      
    }
    void OnTriggerEnter(Collider other){
      if(other.CompareTag("Player")){
        cm.lastCheckPointPos = transform.position;
        cm.Save_Health(health_amount.currentHealth);
      }
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
