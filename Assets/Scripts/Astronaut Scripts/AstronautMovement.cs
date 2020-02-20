using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 4;   //Movement Speed of the Player
    public Vector2 movement;           //Movement Axis
    public Rigidbody2D body;      //Player Rigidbody Component

    void Start ()
    {
        movement = new Vector2(0.0f, 0.0f);
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + (movement * movementSpeed * Time.fixedDeltaTime));
    }
}
