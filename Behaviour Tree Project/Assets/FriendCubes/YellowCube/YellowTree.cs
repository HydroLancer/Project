using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowTree : MonoBehaviour
{

    //Yellow Delegates 
    static LeafNode.methodDelegate yellowMove = new LeafNode.methodDelegate(YellowActions.YellowToBoss);
    static LeafNode.methodDelegate yellowGoHome = new LeafNode.methodDelegate(YellowActions.YellowToHome);
    static LeafNode.methodDelegate yellowCheckTurn = new LeafNode.methodDelegate(YellowActions.turnCheck);
    static LeafNode.methodDelegate yellowEndTurn = new LeafNode.methodDelegate(YellowActions.endTurn);

    /////////////////Yellow's Tree////////////////////////////////
    Selector Yellow = new Selector();
    static LeafNode yellowTurnCheck = new LeafNode(yellowCheckTurn);
    Sequence yellowAttackBoss = new Sequence();
    LeafNode yellowMoveToBoss = new LeafNode(yellowMove);
    LeafNode yellowReturnHome = new LeafNode(yellowGoHome);
    LeafNode yellowTurnEnd = new LeafNode(yellowEndTurn);

    //Inverters
    Inverter yellowTurnChecker = new Inverter(yellowTurnCheck);

    //object for stats and getters/setters
    public static YellowStats stats = new YellowStats();

    // Start is called before the first frame update
    void Start()
    {
        Yellow.addChild(yellowTurnChecker);
        yellowAttackBoss.addChild(yellowMoveToBoss);
        yellowAttackBoss.addChild(yellowReturnHome);
        yellowAttackBoss.addChild(yellowTurnEnd);
        Yellow.addChild(yellowAttackBoss);
    }

    // Update is called once per frame
    void Update()
    {
        Yellow.run();
    }
}
