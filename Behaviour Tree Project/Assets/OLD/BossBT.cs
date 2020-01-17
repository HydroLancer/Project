using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public static class Globals
{
    public static bool bumped = false;      //Ideally should change these into an enum
    public static bool jumped = false;      //but this works for now. Will update later. 
    public static bool home   = false;
}

public class BossBT : MonoBehaviour
{
    string bossHP;
    Text textbox;

    //this just makes an instance of a boss's statuses to be used, probably in a main later. 
    BossStatus bossStatus = new BossStatus();


    Sequence root = new Sequence();
    // Start is called before the first frame update
    void Start()
    {
        textbox = GameObject.Find("Boss HP Label").GetComponent<Text>();

        bossHP = bossStatus.getHP().ToString();
        
        LeafNode.methodDelegate movement = new LeafNode.methodDelegate(MoveToEnemy);
        LeafNode.methodDelegate jump = new LeafNode.methodDelegate(Jump);
        LeafNode.methodDelegate home = new LeafNode.methodDelegate(Home);
        LeafNode homeAction = new LeafNode(home);
        LeafNode moveAction = new LeafNode(movement);
        LeafNode jumpAction = new LeafNode(jump);

        root.addChild(moveAction);
        root.addChild(jumpAction);
        root.addChild(homeAction);

    }

    // Update is called once per frame
    void Update()
    {
        root.run();
        bossHP = bossStatus.getHP().ToString();
        textbox.text = "Boss HP: " + bossHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FriendCube (1)")
        {
            Globals.bumped = true;
            Globals.home = false;
        }
        if (other.gameObject.name == "BossHome")
        {
            Globals.home = true;
            Globals.bumped = false;
            Globals.jumped = false;
        }
    }

    private states MoveToEnemy()
    {
        GameObject targetObject = GameObject.Find("FriendCube (1)");
        NavMeshAgent agent = GameObject.Find("BossCube").GetComponent<NavMeshAgent>();
        while (!Globals.bumped)
        {
            if (!Globals.bumped)
            {
                agent.SetDestination(targetObject.transform.position);
                if (GameObject.Find("BossCube").transform.position.z - targetObject.transform.position.z > 500.0f)
                {
                    return states.FAILURE;  //technically shouldn't happen, but hey wilder things have happened
                }
                return states.RUNNING;  //should come back to this node if it's in a sequence until it fulfills either success or failure state
            }
        }
        return states.SUCCESS;
    }

    private states Jump()
    {
        if (Globals.bumped && !Globals.jumped)
        {
            Rigidbody rb = GameObject.Find("BossCube").GetComponent<Rigidbody>();
            rb.AddForce(0.0f, 100.0f, 0.0f, ForceMode.Impulse);
            Debug.Log("Boing!");
            Globals.jumped = true;
            return states.SUCCESS;    //will always suceed, is just a happy little bounce.
        }
        else
        {
            return states.FAILURE;
        }
    }

    private states Home()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        GameObject homeLocation = GameObject.Find("BossHome");
        if (Globals.jumped)
        {
            agent.SetDestination(homeLocation.transform.position);
            if (!Globals.home)
            {
                return states.RUNNING;
            }
            else { return states.SUCCESS; }
        }
        return states.FAILURE;
    }
}

//old style stuff I was using. kept for posterity

//class MoveToEnemyTask : Node
//{
//    public override states run()
//    {
//        GameObject targetObject = GameObject.Find("FriendCube (1)");
//        NavMeshAgent agent = GameObject.Find("BossCube").GetComponent<NavMeshAgent>();
//            while (!Globals.bumped)
//            {
//                agent.SetDestination(targetObject.transform.position);
//                if (GameObject.Find("BossCube").transform.position.z - targetObject.transform.position.z > 500.0f)
//                {
//                    currentState = states.FAILURE;
//                    return currentState;  //technically shouldn't happen, but hey wilder things have happened
//                }
//                currentState = states.RUNNING;
//                return currentState;  //should come back to this node if it's in a sequence until it fulfills either success or failure state
//            }
//            Debug.Log("Made it!");
//            currentState = states.SUCCESS;
//            return currentState;  //succeeded at moving toward its enemy
//    }      
//} 

//class JumpTask : Node
//{
//    public override states run()
//    {
//            Rigidbody rb = GameObject.Find("BossCube").GetComponent<Rigidbody>();
//            rb.AddForce(0.0f, 100.0f, 0.0f, ForceMode.Impulse);
//            Debug.Log("Boing!");
//            currentState = states.SUCCESS;
//            return currentState;    //will always suceed, is just a happy little bounce.
//    }
//}

