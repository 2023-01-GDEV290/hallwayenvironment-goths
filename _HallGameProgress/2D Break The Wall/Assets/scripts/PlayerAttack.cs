using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;

    private bool attacking = false; //Whether or not the player is attacking

    private float atkTime = 0.25f;
    private float timer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
     
        if(Input.GetKeyDown(KeyCode.R))
        {
            Attack();
        }

        if(attacking == true) //If the Player attacks while they are already attacking
        {
            timer += Time.deltaTime;

            if(timer >= atkTime)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }

        }

    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }

}