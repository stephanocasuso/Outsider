using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos_CheckPoint : MonoBehaviour
{
  private CheckPointMaster cm;
  //private Health health_amount;

    // Start is called before the first frame update
  void Awake(){
    cm = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckPointMaster>();
    //health_amount = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
  }

  void Start()
  {
    transform.position = cm.lastCheckPointPos;
    //health_amount.maxHealth = cm.top_health;
   // health_amount.currentHealth = cm.last_health;
  }
  

    // Update is called once per frame
    void Update()
    {
      // health_amount.maxHealth = 100;
       if(Input.GetKeyDown(KeyCode.T)){
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       }
    }
}
