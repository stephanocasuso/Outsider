using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour

{
  private CheckPointMaster cm;
  void Awake(){
  }
  void Start()
    {
      cm = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckPointMaster>();
      
    }
    void OnTriggerEnter(Collider other){
      if(other.CompareTag("Player")){
        cm.lastCheckPointPos = transform.position;
      }
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
