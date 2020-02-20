using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DroneMovement : MonoBehaviour
{
    [SerializeField]
    private string objectTag = "Player";
    [SerializeField]
    private float RotateSpeed = 0;
    [SerializeField]
    private float Radius = 0;
    [SerializeField]
    private float droneCount = 0;

    public Rigidbody2D body = new Rigidbody2D(); 
    
    private GameObject objectToOrbit;
    private Vector2 center;
    private float angle;
    private float oldCos;
    private float speedChange = 1.34f;

    private void Start()
    {
        objectToOrbit = GameObject.FindWithTag(objectTag);
        center = objectToOrbit.transform.position;
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        center = objectToOrbit.transform.position;
        oldCos = Mathf.Cos(angle);
        angle += RotateSpeed * Time.deltaTime * speedChange;
        Debug.Log(Time.deltaTime);
        Vector2 offset;
        
        if(objectTag == "Lead Drone 1"){
            //Counter Clockwise
            offset = new Vector2(Mathf.Cos(angle + droneCount) * Radius, Mathf.Sin(angle + droneCount) * (Radius/2));
        } else {
            //Clockwise
            offset = new Vector2(Mathf.Sin(angle + droneCount) * Radius, Mathf.Cos(angle + droneCount) * (Radius/2));
        
        }
        
        transform.position = center + offset;

        // //!NOT WORKING 
        // float newCos = Mathf.Cos(angle);
        // bool isIncreasing = newCos - oldCos > 0;
        // //As cos approaches 1 from 0 it should increase the rotate speed
        // if(newCos >= 0 && newCos < 1 && isIncreasing){
        //     speedChange = 1.34F;
        // } 
        // //as cos approaches 0 from 1 it should decrease the rotate speed
        // else if(newCos <= 1 && newCos > 0 && !isIncreasing)
        // {
        //     speedChange = 1/1.34F;
        // }
        // //as cos approaches -1 from 0 it should increase the rotate speed
        // else if(newCos <= 0 && newCos > -1 && isIncreasing)
        // {
        //     speedChange = 1.34F;
        // }
        // //as cos approaches 1 from 0 it should decrease the rotate speed
        // else if(newCos >= -1 && newCos < 0 && !isIncreasing)
        // {
        //      speedChange = 1/1.34F;
        // }
        // Debug.Log("newCos: " + newCos);
        // Debug.Log("oldCos: " + oldCos);
        // Debug.Log("oldCos: " + oldCos);
        
    }
     
}
