using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Health : MonoBehaviour
{
    public float Max_Health;
    private float Current_Health;

    private void OnEnable()
    {
        Current_Health = Max_Health;
    }

    public void TakeDamage(float damage){
        Current_Health -= damage;
        if(Current_Health <= 0){
            Die();
        }
    }

    private void Die(){
        gameObject.SetActive(false);
    }

}
