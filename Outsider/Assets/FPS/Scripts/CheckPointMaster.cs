using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointMaster : MonoBehaviour
{
  private static CheckPointMaster instance;
  public Vector3 lastCheckPointPos;
  void Awake(){ //ensures that loading the scene / respawning doesnt delete all the check points
    if(instance == null){
      instance = this;
      DontDestroyOnLoad(instance);
    }
    else{
      Destroy(gameObject);
    }
  }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
