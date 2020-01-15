using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node
{
    public delegate states NodeReturn();

    protected states currentState; //Node's current state

    public states returnState { get { return currentState; } }  //returns the current state of the node

    public Node()
    {
        //constructor.. each deriative is different
    }

    public abstract states run();
}
