using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : Node
{
    private Node m_node;

    public Inverter(Node node)
    {
        m_node = node;
    }
    public override states run()
    {
        switch (m_node.run())
        {
            case states.FAILURE:
                return states.SUCCESS;
            case states.SUCCESS:
                return states.FAILURE;
            case states.RUNNING:
                currentState = states.RUNNING;
                return currentState;
        }
        currentState = states.SUCCESS;
        return currentState;
    }
}
