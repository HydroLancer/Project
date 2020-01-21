using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class YellowActions : MonoBehaviour
{
    private static bool home = false;
    private static bool attacked = false;

    //Ends the current turn and adjusts the current turn to the next NPC
    public static states endTurn()
    {
        ControllerScript.current = currentTurn.BLUE;
        attacked = false;
        return states.SUCCESS; 
    }
    //Applied to an inverter, checks to see if it's currently their turn
    public static states turnCheck()
    {
        YellowUpdate.treeStatus = "Idle/Checking Turn";
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
        YellowUpdate.treeStatus = "Moving to Boss";
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
            YellowUpdate.treeStatus = "Returning Home";
            agent.SetDestination(GameObject.Find("HealerHome").GetComponent<Transform>().position);
            return states.RUNNING;
        }
        else if (!attacked && home)
        {
            return states.SUCCESS;
        }
        return states.FAILURE;

    }

    //Casts shield on specific NPC
    public static states CastShieldOnBlue()
    {
        if (BlueTree.stats.shieldBuffed)
        {
            return states.FAILURE;
        }
        else
        {
            YellowTree.particleShooter = GameObject.Find("ShieldCastBlue").GetComponent<ParticleSystem>();
            YellowTree.particleShooter.Play();
            BlueTree.stats.SetShield(200);
            return states.SUCCESS;
        }
    }
    public static states CastShieldOnGreen()
    {
        if (GreenTree.stats.shieldBuffed)
        {
            return states.FAILURE;
        }
        else
        {
            YellowTree.particleShooter = GameObject.Find("ShieldCastGreen").GetComponent<ParticleSystem>();
            YellowTree.particleShooter.Play();
            GreenTree.stats.SetShield(200);
            return states.SUCCESS;
        }
    }
    public static states CastShieldOnSelf()
    {
        if (YellowTree.stats.shieldBuffed)
        {
            return states.FAILURE;
        }
        else
        {
            YellowTree.particleShooter = GameObject.Find("ShieldCastSelf").GetComponent<ParticleSystem>();
            YellowTree.particleShooter.Play();
            YellowTree.stats.SetShield(200);
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
            BossTree.stats.TakeDamage(YellowTree.stats.DoDamage());
            home = false;
            attacked = true;
        }
        if (other.name == "Casting Spot")
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