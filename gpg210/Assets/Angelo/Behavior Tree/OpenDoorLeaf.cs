﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorLeaf : Node
{
    public OpenDoorLeaf(int desiredPriority, string desiredName, Handler desiredHandler) : base(desiredPriority, desiredName, desiredHandler)
    {
        this.NodePriority = desiredPriority;
        this.NodeName = desiredName;
        this.NodeHandler = desiredHandler;
    }


    public override void NodeBehavior()
    {
       if(this.NodeHandler.IsInTrigger == true)
        {
            //Update the door timer
            this.NodeHandler.DoorOpenTimer += Time.deltaTime;

            if (this.NodeHandler.DoorOpenTimer >= 3)
            {
                this.NodeHandler.DoorCollider.gameObject.GetComponentInParent<MonoItem>().CurrentBehavior();
                this.NodeHandler.DoorOpenTimer = 0f;
                SetNodeStatus(NodeStates.success);
            }
        }
    }
}
