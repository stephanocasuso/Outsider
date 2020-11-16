using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_Items : MonoBehaviour
{// All Methods are called by the Item_Checker Instance.
  
  private CheckPointMaster cpm;
  private Item_Checker item_checker;
  public bool Shotgun_Taken = false;
  public bool Launcher_Taken = false;
  public bool JetPack_Taken = false;
    
    void Awake(){
     item_checker = GetComponent<Item_Checker>();
     cpm = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckPointMaster>();
  }

    void Start()
    {
      Have_The_Shotgun();
      Have_The_Launcher();
      Have_The_JetPack();
        
    }
    public void Have_The_Shotgun(){
      if(item_checker.Shotgun_grabbed == true || cpm.Shotgun_TakenC == true){
        Shotgun_Taken = true;
        cpm.True_Shotgun();
        return;
      }
      else{
        return;
      }
    }

    public void Have_The_Launcher(){
      if(item_checker.Launcher_grabbed == true || cpm.Launcher_TakenC == true){
        Launcher_Taken = true;
        cpm.True_Launcher();
        return;
      }
      else{
        return;
      }
    }

    public void Have_The_JetPack(){
      if(item_checker.JetPack_grabbed == true || cpm.JetPack_TakenC == true){
        JetPack_Taken = true;
        cpm.True_JetPack();
        return;
      }
      else{
        return;
      }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}