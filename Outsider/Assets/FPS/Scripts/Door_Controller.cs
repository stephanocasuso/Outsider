using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This script is to be attached to the White cube in the Simons_Cubes Prefab. The oj=bject is called Door_Opener
// The activated requires for the cube to be shot once, but will not fuction until the needed varialbe in GameController = 2
// You can assign pratically any wall / door to this script  as the door variable in Unity's inspector
public class Door_Controller : MonoBehaviour
{	
	public GameObject Door;
	public bool doorIsOpening;
	
	
	void Update() {  // moves the door up by 5 up in the y vector.
		if (doorIsOpening == true){
			Door.transform.Translate (Vector3.up * Time.deltaTime * 5);
		//if doorIsOpening is true, then open the door
		}
		if (Door.transform.position.y > 7f ){
			doorIsOpening = false;
		// If the door is already open, leave it alone.
		}
        
	}
	
	void OnMouseDown(){ // activates the door moving
		if(GameController.Instance.needed == GameController.Instance.win){
			doorIsOpening = true;
		}
	}
}


