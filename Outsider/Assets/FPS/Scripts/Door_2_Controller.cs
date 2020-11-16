using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_2_Controller : MonoBehaviour
{	
	public GameObject Door;
	public bool doorIsOpening;
	private Game_2_Controller G2C;
	public int retry = 0;

	void Awake(){
		G2C = GetComponent<Game_2_Controller>();
	}
	
	
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
		retry = 1;
		Debug.Log("Hit Detected");
		if(Game_2_Controller.Instance.needed == Game_2_Controller.Instance.win){
			doorIsOpening = true;
		}
		else if(retry == 1){
		retry = 0;
		StartCoroutine(Game_2_Controller.Instance.Retry_Signal());
		}
		
	}

}


