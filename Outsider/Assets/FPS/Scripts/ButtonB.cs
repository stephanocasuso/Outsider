using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonB : MonoBehaviour
{
	public int id;
	public Animator anim;

	void Start()
	{
		id = transform.GetSiblingIndex();
	}

	void OnMouseDown() // remove for the non-inteaction one
	{
		if (!GameController.simonIsSaying)
		{
			GameController.Instance.PlayAudio(id);
			Action();
			GameController.Instance.PlayerAction(this);
		}
		
	}
	public void Action()
	{
	anim.enabled = true;
	anim.SetTrigger("pop");
	}
	


}
