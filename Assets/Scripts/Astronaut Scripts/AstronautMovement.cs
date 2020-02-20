using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 4f;   //Movement Speed of the Player
    public Vector2 movement;            //Movement Axis
    public Rigidbody2D rbody;           //Player Rigidbody Component
    private Vector2 newPos;      
    //IsometricCharacterRenderer isoRenderer;

    void Start ()
    {
        //starting position
        movement = new Vector2(0.0f, 0.0f);
        rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 currentPos = rbody.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        movement = inputVector * movementSpeed;
        newPos = currentPos + movement * Time.fixedDeltaTime;
        //isoRenderer.SetDirection(movement);
    }

    void FixedUpdate()
    {
        rbody.MovePosition(newPos);
    }
}
