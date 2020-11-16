using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_2_B : MonoBehaviour
{
	public int id;
	public Animator anim;
	private Game_2_Controller follow;

	void Start()
	{
		id = transform.GetSiblingIndex();
		follow = GameObject.FindGameObjectWithTag("Follow").GetComponent<Game_2_Controller>();
	}
	
		void OnMouseDown() // remove for the non-inteaction one
		{
			if (follow.true_puzzle == 1){
				if (!Game_2_Controller.simonIsSaying)
				{
					Game_2_Controller.Instance.PlayAudio(id);
					Action();
					Game_2_Controller.Instance.PlayerAction(this);
				}
			}	
			
	
		}

	public void Action()
	{
	anim.enabled = true;
	anim.SetTrigger("pop");
	}
	


}
