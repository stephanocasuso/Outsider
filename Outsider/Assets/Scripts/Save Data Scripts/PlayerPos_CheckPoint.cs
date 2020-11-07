using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos_CheckPoint : MonoBehaviour
{
  private CheckPointMaster cm;

    // Start is called before the first frame update
  void Awake(){
    cm = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckPointMaster>();
  }

  void Start()
  {
    transform.position = cm.lastCheckPointPos;
  }
  

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.T)){
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       }
    }
}
