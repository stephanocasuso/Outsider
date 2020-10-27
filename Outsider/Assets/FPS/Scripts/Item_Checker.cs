using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Checker : MonoBehaviour
// All methods are called by the Load_Items Instance.
{	
  private CheckPointMaster cpm;
  private Load_Items load_items;
  private Rigidbody Buckshot;
  private Rigidbody Launch;
  private Rigidbody Jet;
  public GameObject Shotgun;
  public GameObject Launcher;
  public GameObject JetPack;
  public bool Shotgun_grabbed = false;
  public bool Launcher_grabbed = false;
  public bool JetPack_grabbed = false; 

  void Awake(){
     load_items = GetComponent<Load_Items>();
     cpm = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckPointMaster>();
     Buckshot = GameObject.FindGameObjectWithTag("BuckShot").GetComponent<Rigidbody>();
     Launch = GameObject.FindGameObjectWithTag("Launcher").GetComponent<Rigidbody>();
     Jet = GameObject.FindGameObjectWithTag("FlyAway").GetComponent<Rigidbody>();
  }

  void Start()
  {
    Check_Shotgun();
    Check_Launcher();
    Check_JetPack();


  }
  

  public void Load_Shotgun(){ // Warps the shotgun to your location
    if(Shotgun_grabbed == false && cpm.Shotgun_TakenC == true){
      Shotgun.transform.position = new Vector3(cpm.lastCheckPointPos.x, cpm.lastCheckPointPos.y, cpm.lastCheckPointPos.z);
    } // Transforming the position of the collider and weapon does not help fix the problem
  // Warps the local Position of the gun to the gloabl postion of the parent / player
      return;
  }


  public void Load_Launcher(){ // Warps the Launcher to your location
   if(Launcher_grabbed == false && cpm.Launcher_TakenC == true){
      Launcher.transform.position = new Vector3(cpm.lastCheckPointPos.x, cpm.lastCheckPointPos.y, cpm.lastCheckPointPos.z); // Warps the local Position of the gun to the
// the gloabl postion of the parent
      return;
    }
  }
    

  public void Load_JetPack(){ // Warps the shotgun to your location
    if(JetPack_grabbed == false && cpm.JetPack_TakenC == true){
      JetPack.transform.position = new Vector3(cpm.lastCheckPointPos.x, cpm.lastCheckPointPos.y, cpm.lastCheckPointPos.z);
    } // Transforming the position of the collider and weapon does not help fix the problem
  // Warps the local Position of the gun to the gloabl postion of the parent / player
      return;
  }

  void Update() {
          if(Input.GetKeyDown(KeyCode.W) ||Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Space) ){
            if(Shotgun_grabbed == false){
              Check_Shotgun();
            }
            else if(Launcher_grabbed == false){
              Check_Launcher();
            }
             else if(JetPack_grabbed == false){
              Check_JetPack();
            }
          
        } 
  }

  private void Check_Shotgun(){
     if(Shotgun ?? false ){ // Checks to see if the prefab is null / taken / destroyed
     Shotgun_grabbed = false;
     Buckshot.isKinematic = false;
     Load_Shotgun();
     return; // ^ Having the line for the load functions works here consistently
     }
    else{
      Shotgun_grabbed = true;
      load_items.Have_The_Shotgun();
      return;
     }
  }

    private void Check_Launcher(){
     if(Launcher ?? false ){ // Checks to see if the prefab is null / taken / destroyed
     Launcher_grabbed = false;
     Launch.isKinematic = false;
     Load_Launcher();
     return; // ^ Have the line for the load functions works here consistently
     }
     else{
       Launcher_grabbed = true;
       load_items.Have_The_Launcher();
       return;
     }
    }

  private void Check_JetPack(){
     if(JetPack ?? false){ // Checks to see if the prefab is null / taken / destroyed
     JetPack_grabbed = false;
     Jet.isKinematic = false;
     Load_JetPack();
     return; // ^ Have the line for the load functions works here consistently
     }
     else{
       JetPack_grabbed = true;
       load_items.Have_The_JetPack();
       return;
        }
    }

}
