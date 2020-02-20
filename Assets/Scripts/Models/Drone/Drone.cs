using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Scripts.Models.StatBlock;
//using ArgumentException;

public class Drone
{
    private string Name { get; set; }    
    private string OwnTag { get; set; }
    private int Hierarchy { get; set; }
    private string ParentTag { get; set; }
    private int ChildDroneCount { get; set; }

    public Drone(string name, string parentTag, int parentChildrenDroneCount)
    {
        BaseStats droneStats = new BaseStats();

        if(parentChildrenDroneCount < 3)
        {
            throw new ArgumentException("Drones can only have 3 followers");
        }
        else
        {
            //default drone setup
            Name = name;
            droneStats.HealthPoints = 3; 
            ChildDroneCount = 0;
            if(parentTag == null)
            {
                OwnTag = "Lead Drone " + parentChildrenDroneCount.ToString();
                Hierarchy = 0;
                ParentTag = null;
            }
            else if(parentTag == "Player")
            {
                OwnTag = "Lead Drone " + parentChildrenDroneCount.ToString();
                Hierarchy = 1;
                ParentTag = parentTag;
            }
            else
            {
                OwnTag = "Follower Drone " + parentChildrenDroneCount.ToString();
                Hierarchy = 2;
                ParentTag = parentTag;
            }

            droneStats.Movement = new Movement(Hierarchy);
        }
    }
}
