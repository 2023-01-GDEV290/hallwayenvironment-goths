using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;

    public ContactFilter2D movementFilter;

    Vector2 movementInput;

    Rigidbody2D rb;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            print(count);

            if(count == 0)
            {
                rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
                print("Moving!");
                //audioSource.Play();
            }

        }

    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }
}
