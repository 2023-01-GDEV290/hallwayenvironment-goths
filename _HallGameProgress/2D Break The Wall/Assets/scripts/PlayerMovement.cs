using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public AudioSource walkNoise;

    public ContactFilter2D movementFilter;

    Vector2 movementInput;

    private bool isWalking;

    Vector2 movement;

    public Animator animator;

    Rigidbody2D rb;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isWalking = false;
        InvokeRepeating("WalkingSoundPlay",1f,1f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(movementInput != Vector2.zero)
        {
            print("We are being called!");
            int count = rb.Cast(
                movementInput, //X and Y values between -1 and 1 that represent the direction from the body to look for collisions.
                movementFilter, //The setting that determines where a collision can occur on such as layers to collide with
                castCollisions, //List of the collisions found into after the Cast is finished
                moveSpeed * Time.fixedDeltaTime + collisionOffset); //Amount of cast, equal to the offset plus the movement
            isWalking = false;
            print(count);

            if(count == 0)
            {
                rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);

                print("Moving!");
                isWalking = true;
            }

        }

    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal",movement.x);
        animator.SetFloat("Vertical",movement.y);
        animator.SetFloat("Speed",movement.sqrMagnitude);

    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void WalkingSoundPlay()
    {
        if(isWalking == true)
        {
        walkNoise.Play();
        print("Walk Audio instance");
        }
    }
}
