using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GreenActions : MonoBehaviour
{
    private static bool home = false;
    private static bool attacked = false;
    public static states endTurn()
    {
        if (attacked && home)
        {
            attacked = false;
            ControllerScript.current = currentTurn.BOSS;
            return states.SUCCESS;
        }
        return states.FAILURE;
    }
    public static states turnCheck()
    {
        GreenUpdate.treeStatus = "Idle/Checking Turn";
        switch (ControllerScript.current)
        {
            case currentTurn.GREEN:
                return states.SUCCESS;
            default:
                return states.FAILURE;
        }
    }

    public static states GreenToBoss()
    {
        NavMeshAgent agent = GameObject.Find("BuffCube").GetComponent<NavMeshAgent>();

        if (!attacked)
        {
            GreenUpdate.treeStatus = "Moving to Boss";
            agent.SetDestination(GameObject.Find("BossHome").GetComponent<Transform>().position);
            return states.RUNNING;
        }
        else
        {
            return states.SUCCESS;
        }
    }

    public static states GreenToHome()
    {
        NavMeshAgent agent = GameObject.Find("BuffCube").GetComponent<NavMeshAgent>();

        if (!home)
        {
            GreenUpdate.treeStatus = "Returning Home";
            agent.SetDestination(GameObject.Find("BuffHome").GetComponent<Transform>().position);
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
        if (other.name == "BuffHome")
        {
            home = true;
        }
    }
}