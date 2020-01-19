using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    private List<Node> children = new List<Node>();

    public void addChild(Node child) { children.Add(child); }

    public override states run()
    {
        bool anyChildRunning = false;
        foreach (Node child in children)
        {
            switch (child.run())
            {
                case states.FAILURE:
                    currentState = states.FAILURE;
                    return currentState;
                case states.SUCCESS:
                    continue;
                case states.RUNNING:
                    anyChildRunning = true;
                    continue;
                default:
                    currentState = states.FAILURE;
                    return currentState;
            }
        }

        if (anyChildRunning)
        {
            currentState = states.RUNNING;
        }
        else
        {
            currentState = states.SUCCESS;
        }
        return currentState;
    }
}
