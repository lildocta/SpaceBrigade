using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using ArgumentException;

public class Drone
{
    private string name
    { get; set; }
    
    private string ownTag
    { get; set; }
    private int heiarchy
    {get; set;}
    private string parentTag
    { get; set; }
    private int childDroneCount
    { get; set; }

    private int health
    { get; set;}
    private MovementSettings movementSettings
    { get; set;}

    public Drone(string name, string parentTag, int parentChildrenDroneCount)
    {
        if(parentChildrenDroneCount < 3)
        {
            throw new ArgumentException("Drones can only have 3 followers");
        }
        else
        {
            //default drone setup
            name = this.name;
            health = 3; 
            childDroneCount = 0;
            if(parentTag == null)
            {
                ownTag = "Lead Drone " + parentChildrenDroneCount.ToString();
                heiarchy = 0;
                parentTag = null;
            }
            else if(parentTag == "Player")
            {
                ownTag = "Lead Drone " + parentChildrenDroneCount.ToString();
                heiarchy = 1;
                parentTag = this.parentTag;
            }
            else
            {
                ownTag = "Follower Drone " + parentChildrenDroneCount.ToString();
                heiarchy = 2;
                parentTag = this.parentTag;
            }
            MovementSettings newMovement = new MovementSettings(heiarchy);
            movementSettings = newMovement;
        }
    }

    private class MovementSettings{
        private float rotateSpeed
        { get; set;}
        private float radius
        { get; set;}
        
        public MovementSettings(int heiarchy)
        {
            
            switch (heiarchy)
            {
                case 1:
                    rotateSpeed = 1F;
                    radius = 3.14F;
                    break;
                case 2:
                    rotateSpeed = .75F;
                    radius = 1F;
                    break;
                default:
                    Console.WriteLine("The code is heckin broked dawg");
                    break;
            }
        }
    }
}
