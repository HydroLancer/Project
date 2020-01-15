using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafNode : Node
{
    //Leaf nodes use delegate methods to execute actions - though this method is kinda restrictive.
    public delegate states methodDelegate();

    private methodDelegate actualAction;

    //constructor to set the delegate to be actioned on
    public LeafNode(methodDelegate action)
    {
        actualAction = action;
    }

    public override states run()
    {
        switch (actualAction())
        {
            case states.FAILURE:
                currentState = states.FAILURE;
                return currentState;
            case states.RUNNING:
                currentState = states.RUNNING;
                return currentState;
            case states.SUCCESS:
                currentState = states.SUCCESS;
                return currentState;
            default:
                currentState = states.FAILURE;
                return currentState;
        }
    }
}
