using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossActions : MonoBehaviour
{
    //Various bools to allows nodes to succeed/fail/run
    static private bool attacked = false;
    static private bool home = false;
    static private bool targetAcquired = false;

    //set during TargetEnemy() and used during AttackEnemy() to allow for randomised attacks
    static Transform target;

    //used in TargetEnemy() to allow for random attacks
    static System.Random rng = new System.Random();

    //called at the end of each sequence node to end the boss's turn, and make the next character go.
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

    //used in an inverter node
    //SUCCESS is turned into FAIL up the chain to allow the selector node to move along to the next
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

    //randomised function, makes the boss target a random one of its enemies using system.random
    public static states TargetEnemy()
    {
        int targetToHit;
        if (!targetAcquired)
        {
            targetToHit = rng.Next(1, 4);
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
                case 4:
                    target = GameObject.Find("BeserkerCube").GetComponent<Transform>();
                    targetAcquired = true;
                    return states.SUCCESS;
                default:
                    return states.FAILURE;
            }
        }
        return states.SUCCESS;
        
    }

    //makes the boss move to its target
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

    //makes the boss return home
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

    //There's probably a more efficient way of doing this, but basically whenever the entity holding the script enters a collider of the name specified
    //it basically makes the boss do an attack and set the conditions to make the next node (return home) to set to RUNNING
    private void OnTriggerEnter(Collider other)
    {
        ParticleSystem boop;
        if (other.name == "BeserkerHome")
        {
            boop = GameObject.Find("BlueDamaged").GetComponent<ParticleSystem>();
            boop.Play();
            BlueTree.stats.TakeDamage(BossTree.stats.DoDamage());
            home = false;
            attacked = true;
        }
        else if ( other.name == "HealerHome")
        {
            boop = GameObject.Find("YellowDamaged").GetComponent<ParticleSystem>();
            boop.Play();
            YellowTree.stats.TakeDamage(BossTree.stats.DoDamage());
            home = false;
            attacked = true;
        }
        else if (other.name == "BuffHome")
        {
            boop = GameObject.Find("GreenDamaged").GetComponent<ParticleSystem>();
            boop.Play();
            GreenTree.stats.TakeDamage(BossTree.stats.DoDamage());
            home = false;
            attacked = true;
        }

        if (other.name == "BossHome")
        {
            Transform wiggles = this.GetComponent<Transform>();
            wiggles.Rotate(0.0f, 180.0f, 0.0f, Space.World);
            home = true;
        }
    }
}
