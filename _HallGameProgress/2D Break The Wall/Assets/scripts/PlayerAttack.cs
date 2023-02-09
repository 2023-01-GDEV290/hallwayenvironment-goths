using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;

    public Animator animator;

    private bool attacking = false; //Whether or not the player is attacking

    private float atkTime = 0.25f;
    private float timer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    animator.SetBool("PlayerAttack", attacking);
    
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

    void Attack()
    {
        
        
        attacking = true;
        animator.SetTrigger("PlayerAttack");
        attackArea.SetActive(attacking);
        
    }

    //void PlayerAttack()
    //{
        //animator.
    //}


}
