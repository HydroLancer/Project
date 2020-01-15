using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlueActions : MonoBehaviour
{
    private static bool home = false;
    private static bool attacked = false;

    public static states endTurn()
    {
        if (attacked && home)
        {
            ControllerScript.current = currentTurn.GREEN;
            attacked = false;
            return states.SUCCESS;
        }
        return states.FAILURE;
    }
    public static states turnCheck()
    {
        switch (ControllerScript.current)
        {
            case currentTurn.BLUE:
                return states.SUCCESS;
            default:
                return states.FAILURE;
        }
    }

    public static states BlueToBoss()
    {
        NavMeshAgent agent = GameObject.Find("BeserkerCube").GetComponent<NavMeshAgent>();

        if (!attacked)
        {
            agent.SetDestination(GameObject.Find("BossHome").GetComponent<Transform>().position);
            return states.RUNNING;
        }
        else
        {
            return states.SUCCESS;
        }
    }

    public static states BlueToHome()
    {
        NavMeshAgent agent = GameObject.Find("BeserkerCube").GetComponent<NavMeshAgent>();
        
        if (!home)
        {
            agent.SetDestination(GameObject.Find("BeserkerHome").GetComponent<Transform>().position);
            return states.RUNNING;
        }
        else
        {
            return states.SUCCESS;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "BossHome")
        {
            home = false;
            attacked = true;
        }
        if (other.name == "BeserkerHome")
        {
            home = true;
        }
    }
}