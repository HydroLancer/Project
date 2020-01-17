using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTree : MonoBehaviour
{
    //Green Delegates
    static LeafNode.methodDelegate greenMove = new LeafNode.methodDelegate(GreenActions.GreenToBoss);
    static LeafNode.methodDelegate greenGoHome = new LeafNode.methodDelegate(GreenActions.GreenToHome);
    static LeafNode.methodDelegate greenCheckTurn = new LeafNode.methodDelegate(GreenActions.turnCheck);
    static LeafNode.methodDelegate greenEndTurn = new LeafNode.methodDelegate(GreenActions.endTurn);

    //////////////Green's Tree///////////////////////////
    Selector Green = new Selector();
    static LeafNode greenTurnCheck = new LeafNode(greenCheckTurn);
    Sequence greenAttackBoss = new Sequence();
    LeafNode greenMoveToBoss = new LeafNode(greenMove);
    LeafNode greenReturnHome = new LeafNode(greenGoHome);
    LeafNode greenTurnEnd = new LeafNode(greenEndTurn);

    //Inverter for turn checking & More
    Inverter greenTurnChecker = new Inverter(greenTurnCheck);

    //object to update stats
    public static GreenStats stats = new GreenStats();

    // Start is called before the first frame update
    void Start()
    {
        Green.addChild(greenTurnChecker);
        greenAttackBoss.addChild(greenMoveToBoss);
        greenAttackBoss.addChild(greenReturnHome);
        greenAttackBoss.addChild(greenTurnEnd);
        Green.addChild(greenAttackBoss);
    }

    // Update is called once per frame
    void Update()
    {

        Green.run();
    }
}
