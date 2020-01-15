using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    //Blue Delegates
    static LeafNode.methodDelegate blueMove = new LeafNode.methodDelegate(BlueActions.BlueToBoss);
    static LeafNode.methodDelegate blueGoHome = new LeafNode.methodDelegate(BlueActions.BlueToHome);
    static LeafNode.methodDelegate blueCheckTurn = new LeafNode.methodDelegate(BlueActions.turnCheck);
    static LeafNode.methodDelegate blueEndTurn = new LeafNode.methodDelegate(BlueActions.endTurn);

    //Yellow Delegates 
    static LeafNode.methodDelegate yellowMove = new LeafNode.methodDelegate(YellowActions.YellowToBoss);
    static LeafNode.methodDelegate yellowGoHome = new LeafNode.methodDelegate(YellowActions.YellowToHome);
    static LeafNode.methodDelegate yellowCheckTurn = new LeafNode.methodDelegate(YellowActions.turnCheck);
    static LeafNode.methodDelegate yellowEndTurn = new LeafNode.methodDelegate(YellowActions.endTurn);

    //Green Delegates
    static LeafNode.methodDelegate greenMove = new LeafNode.methodDelegate(GreenActions.GreenToBoss);
    static LeafNode.methodDelegate greenGoHome = new LeafNode.methodDelegate(GreenActions.GreenToHome);
    static LeafNode.methodDelegate greenCheckTurn = new LeafNode.methodDelegate(GreenActions.turnCheck);
    static LeafNode.methodDelegate greenEndTurn = new LeafNode.methodDelegate(GreenActions.endTurn);

    ///////////////Boss' Tree///////////////////////////
    Selector Boss = new Selector();

    /////////////////Yellow's Tree////////////////////////////////
    Selector Yellow = new Selector();
        static LeafNode yellowTurnCheck = new LeafNode(yellowCheckTurn);
        Sequence yellowAttackBoss = new Sequence();
            LeafNode yellowMoveToBoss = new LeafNode(yellowMove);
            LeafNode yellowReturnHome = new LeafNode(yellowGoHome);
            LeafNode yellowTurnEnd = new LeafNode(yellowEndTurn);

    /////////////////Blue's tree////////////////////////////////
    Selector Blue = new Selector();

        static LeafNode blueTurnCheck = new LeafNode(blueCheckTurn);
        Sequence blueAttackBoss = new Sequence();
            LeafNode blueMoveToBoss = new LeafNode(blueMove);
            LeafNode blueReturnHome = new LeafNode(blueGoHome);
            LeafNode blueTurnEnd = new LeafNode(blueEndTurn);

    //////////////Green's Tree///////////////////////////
    Selector Green = new Selector();
        static LeafNode greenTurnCheck = new LeafNode(greenCheckTurn);
        Sequence greenAttackBoss = new Sequence();
            LeafNode greenMoveToBoss = new LeafNode(greenMove);
            LeafNode greenReturnHome = new LeafNode(greenGoHome);
            LeafNode greenTurnEnd = new LeafNode(greenEndTurn);

    ///////////////Inverters for NPCS//////////////////////////
    Inverter yellowTurnChecker = new Inverter(yellowTurnCheck);
    Inverter blueTurnChecker = new Inverter(blueTurnCheck);
    Inverter greenTurnChecker = new Inverter(greenTurnCheck);

    //Who the fight starts with
    public static currentTurn current = currentTurn.YELLOW;

    // Start is called before the first frame update
    void Start()
    {
            Blue.addChild(blueTurnChecker);
                blueAttackBoss.addChild(blueMoveToBoss);
                blueAttackBoss.addChild(blueReturnHome);
                blueAttackBoss.addChild(blueTurnEnd);
            Blue.addChild(blueAttackBoss);

            Yellow.addChild(yellowTurnChecker);
                yellowAttackBoss.addChild(yellowMoveToBoss);
                yellowAttackBoss.addChild(yellowReturnHome);
                yellowAttackBoss.addChild(yellowTurnEnd);
            Yellow.addChild(yellowAttackBoss);

        Green.addChild(greenTurnChecker);
            greenAttackBoss.addChild(greenMoveToBoss);
            greenAttackBoss.addChild(greenReturnHome);
            greenAttackBoss.addChild(greenTurnEnd);
        Green.addChild(greenAttackBoss);
    }

    // Update is called once per frame
    void Update()
    {
        Blue.run();
        Yellow.run();
        Green.run();
    }
    
}

