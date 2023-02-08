using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private float damage = 1f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<Health>() != null) //If The Object Has a Health system
        {
            Health health = collider.GetComponent<Health>();
            health.TakeDamage(damage);
        }
    }
}
