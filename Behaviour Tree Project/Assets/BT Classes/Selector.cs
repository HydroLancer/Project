using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{
    public List<Node> children = new List<Node>();

    public void addChild(Node child) { children.Add(child); }

    public override states run()
    {
        foreach (Node child in children)
        {
            switch (child.run())
            {
                case states.FAILURE:
                    continue;
                case states.SUCCESS:
                    currentState = states.SUCCESS;
                    return currentState;
                case states.RUNNING:
                    currentState = states.RUNNING;
                    return currentState;
                default:
                    continue;
                    
            }
        }
        currentState = states.FAILURE;
        return currentState;
    }
}
