using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] private float health = 50f;

    public void TakeDamage(float amount){
        health -= amount;

        if(health <= 0f){
            Die();
        }
    }

    public void Die(){
        transform.position = SpawnerController.Instance.RandomPosition();
    }
}
