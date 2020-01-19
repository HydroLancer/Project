using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTree : MonoBehaviour
{
    //Blue Delegates
    static LeafNode.methodDelegate blueMove = new LeafNode.methodDelegate(BlueActions.BlueToBoss);
    static LeafNode.methodDelegate blueGoHome = new LeafNode.methodDelegate(BlueActions.BlueToHome);
    static LeafNode.methodDelegate blueCheckTurn = new LeafNode.methodDelegate(BlueActions.turnCheck);
    static LeafNode.methodDelegate blueEndTurn = new LeafNode.methodDelegate(BlueActions.endTurn);

    /////////////////Blue's tree////////////////////////////////
    public static Selector Blue = new Selector();

    static LeafNode blueTurnCheck = new LeafNode(blueCheckTurn);
    Sequence blueAttackBoss = new Sequence();
    LeafNode blueMoveToBoss = new LeafNode(blueMove);
    LeafNode blueReturnHome = new LeafNode(blueGoHome);
    LeafNode blueTurnEnd = new LeafNode(blueEndTurn);
    Inverter blueTurnChecker = new Inverter(blueTurnCheck);
    public static GenericStats stats;
     
    // Start is called before the first frame update
    void Start()
    {
        stats = new GenericStats("Blue", 1200, 150);
        Blue.addChild(blueTurnChecker);
        blueAttackBoss.addChild(blueMoveToBoss);
        blueAttackBoss.addChild(blueReturnHome);
        blueAttackBoss.addChild(blueTurnEnd);
        Blue.addChild(blueAttackBoss);
    }

    // Update is called once per frame
    void Update()
    {
        Blue.run();
    }
}
