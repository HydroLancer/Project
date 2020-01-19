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
            BlueUpdate.treeStatus = "Idle";
            ControllerScript.current = currentTurn.GREEN;
            attacked = false;
            return states.SUCCESS;
        }
        return states.FAILURE;
    }
    public static states turnCheck()
    {
        BlueUpdate.treeStatus = "Idle/Checking Turn";
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
            BlueUpdate.treeStatus = "Moving to Boss";
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
            BlueUpdate.treeStatus = "Returning Home";
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
        ParticleSystem boop;
        if (other.name == "BossHome")
        {
            boop = GameObject.Find("Boss Damaged").GetComponent<ParticleSystem>();
            boop.Play();
            BossTree.stats.TakeDamage(BlueTree.stats.DoDamage());
            home = false;
            attacked = true;
        }
        if (other.name == "BeserkerHome")
        {
            Transform wiggles = this.GetComponent<Transform>();
            wiggles.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
            home = true;
        }
    }
}