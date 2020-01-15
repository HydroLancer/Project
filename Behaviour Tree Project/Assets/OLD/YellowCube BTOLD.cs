//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class YellowCubeBTOLD : MonoBehaviour
//{
//    //public static FriendlyStats Yellow = new FriendlyStats("HealerCube");

//    //Delegates
//    public static LeafNode.methodDelegate movement = new LeafNode.methodDelegate(MoveToBoss);

//    //root node
//    public Selector root = new Selector();

//    //things coming off root
//    Sequence healing = new Sequence();
//    Sequence attackBoss = new Sequence();
//    Sequence buffing = new Sequence();

//    //Leaf Nodes
//    LeafNode moveNode = new LeafNode(movement);
    
//    // Start is called before the first frame update
//    public void Start()
//    {
//        attackBoss.addChild(moveNode);
//        root.addChild(attackBoss);
//    }

//    // Update is called once per frame
//    public void Update()
//    {
//        root.run();
//    }

//    public static states MoveToBoss()
//    {
//        NavMeshAgent agent = GameObject.Find("HealerCube").GetComponent<NavMeshAgent>();
//        switch (Yellow.currentState)
//        {
//            case FriendlyStates.HOME:
//                //This sets the character's internal state to running at the enemy, and returns the running state for the Behaviour Tree
//                agent.SetDestination(GameObject.Find("BossCube").GetComponent<Transform>().position);
//                Yellow.currentState = FriendlyStates.RUNNING;
//                return states.RUNNING;

//            case FriendlyStates.RUNNING:
//                //this one is pretty much the same as above, also returning Running to the parent
//                agent.SetDestination(GameObject.Find("BossCube").GetComponent<Transform>().position);
//                Yellow.currentState = FriendlyStates.RUNNING;
//                return states.RUNNING;

//            case FriendlyStates.ATTACKING:
//                //if it reaches here, this particular action is done. ATTACKING is set by a collider
//                return states.SUCCESS;

//            //these are here to say something has gone horribly wrong.
//            case FriendlyStates.BUFFING:
//                return states.FAILURE;
//            case FriendlyStates.HEALING:
//                return states.FAILURE;
//            default:
//                return states.FAILURE;

//        }
//    }

//    //Return Home
//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.name == "BossCube")
//        {
//            //currentState = FriendlyStates.ATTACKING;
//        }
//    }
//}
