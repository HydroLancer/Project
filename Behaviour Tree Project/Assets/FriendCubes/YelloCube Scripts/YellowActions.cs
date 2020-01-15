using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class YellowActions : MonoBehaviour
{
    private static bool home = false;
    private static bool attacked = false;


    public static states endTurn()
    {
        if (attacked && home)
        {
            ControllerScript.current = currentTurn.BLUE;
            attacked = false;
            return states.SUCCESS;
        }
        return states.FAILURE;
    }

    //Applied to an inverter, checks to see if it's currently their turn
    public static states turnCheck()
    {
        switch (ControllerScript.current)
        {
            case currentTurn.YELLOW:
                return states.SUCCESS;
            default:
                return states.FAILURE;
        }
    }

    //Sends yellow cube towards the boss
    public static states YellowToBoss()
    {
        NavMeshAgent agent = GameObject.Find("HealerCube").GetComponent<NavMeshAgent>();
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

    //Sends the Yellow cube back to its home spot.
    public static states YellowToHome()
    {
        NavMeshAgent agent = GameObject.Find("HealerCube").GetComponent<NavMeshAgent>();

        if (!home)
        {
            agent.SetDestination(GameObject.Find("HealerHome").GetComponent<Transform>().position);
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
        if (other.name == "HealerHome")
        {
            home = true;
        }
    }
}