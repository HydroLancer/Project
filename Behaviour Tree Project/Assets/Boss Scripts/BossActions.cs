using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossActions : MonoBehaviour
{
    static private bool attacked = false;
    static private bool home = false;
    static private bool targetAcquired = false;

    static Transform target;

    static System.Random rng = new System.Random();

    public static states endTurn()
    {
        if (attacked && home)
        {
            BossUpdate.treeStatus = "Idle";
            ControllerScript.current = currentTurn.YELLOW;
            targetAcquired = false;
            attacked = false;
            return states.SUCCESS;
        }
        return states.FAILURE;
    }
    public static states turnCheck()
    {
        BossUpdate.treeStatus = "Idle/Checking Turn";
        switch (ControllerScript.current)
        {
            case currentTurn.BOSS:
                return states.SUCCESS;
            default:
                return states.FAILURE;
        }
    }

    public static states TargetEnemy()
    {
        int targetToHit;
        if (!targetAcquired)
        {
            targetToHit = rng.Next(1, 3);
            switch (targetToHit)
            {
                case 1:
                    target = GameObject.Find("HealerCube").GetComponent<Transform>();
                    targetAcquired = true;
                    return states.SUCCESS;
                case 2:
                    target = GameObject.Find("BuffCube").GetComponent<Transform>();
                    targetAcquired = true;
                    return states.SUCCESS;
                case 3:
                    target = GameObject.Find("BeserkerCube").GetComponent<Transform>();
                    targetAcquired = true;
                    return states.SUCCESS;
                default:
                    return states.FAILURE;
            }
        }
        return states.SUCCESS;
        
    }

    public static states attackEnemy()
    {
        BossUpdate.treeStatus = "Attacking";
        if (!attacked)
        {
            NavMeshAgent agent = GameObject.Find("BossCube").GetComponent<NavMeshAgent>();
            GreenUpdate.treeStatus = "Moving to Enemy";
            agent.destination = target.position;
            return states.RUNNING;
        }
        else
        {
            return states.SUCCESS;
        }


    }

    public static states BossToHome()
    {
        NavMeshAgent agent = GameObject.Find("BossCube").GetComponent<NavMeshAgent>();

        if (!home)
        {
            BossUpdate.treeStatus = "Returning Home";
            agent.SetDestination(GameObject.Find("BossHome").GetComponent<Transform>().position);
            return states.RUNNING;
        }
        else
        {
            return states.SUCCESS;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "BeserkerHome" || other.name == "HealerHome" || other.name == "BuffHome")
        {
            home = false;
            attacked = true;
        }
        if (other.name == "BossHome")
        {
            home = true;
        }
    }
}
