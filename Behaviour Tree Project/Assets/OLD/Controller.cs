using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
    public Transform actualTarget;
    public Transform target1, target2, target3;
    public Transform home;

    NavMeshAgent agent;

    public bool attacking;

    // Start is called before the first frame update
    void Start()
    {
        actualTarget = target1;
        attacking = true;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attacking)
        {
            agent.SetDestination(actualTarget.position);
        }
        else
        {
            agent.SetDestination(home.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FriendCube")
        {
            attacking = false;
            actualTarget = target2;

        }
        if (other.gameObject.name == "FriendCube (1)")
        {
            attacking = false;
            actualTarget = target3;
        }
        if (other.gameObject.name == "FriendCube (2)")
        {
            attacking = false;
            actualTarget = target1;
        }
        if (other.gameObject.name == "TargetLocation")
        {
            attacking = true;
        }
    }
}
