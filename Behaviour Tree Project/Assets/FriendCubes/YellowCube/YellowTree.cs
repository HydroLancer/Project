using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowTree : MonoBehaviour
{
    //Yellow Delegates 
    //Movements
    static LeafNode.methodDelegate moveToBoss = new LeafNode.methodDelegate(YellowActions.YellowToBoss);
    static LeafNode.methodDelegate returnHome = new LeafNode.methodDelegate(YellowActions.YellowToHome);
    
    //Cast Shields
    static LeafNode.methodDelegate castShieldBlue = new LeafNode.methodDelegate(YellowActions.CastShieldOnBlue);
    static LeafNode.methodDelegate castShieldGreen = new LeafNode.methodDelegate(YellowActions.CastShieldOnGreen);
    static LeafNode.methodDelegate castShieldSelf = new LeafNode.methodDelegate(YellowActions.CastShieldOnSelf);
    static LeafNode.methodDelegate castingAnimation = new LeafNode.methodDelegate(YellowActions.castingAnimation);

    //Turn Checkers
    static LeafNode.methodDelegate checkTurn = new LeafNode.methodDelegate(YellowActions.turnCheck);
    static LeafNode.methodDelegate endTurn = new LeafNode.methodDelegate(YellowActions.endTurn);


    ///////Nodes//////////////////
    //Root
    Selector Yellow = new Selector();

    //Turn Checker
    static LeafNode yellowTurnCheck = new LeafNode(checkTurn);
    static LeafNode EndTurn = new LeafNode(endTurn);

    //Shields
    Selector DoShield = new Selector();

    Selector ShieldSelf = new Selector();
    Selector ShieldGreen = new Selector();
    Selector ShieldBlue = new Selector();

    Sequence actualCastSelf = new Sequence();
    Sequence actualCastBlue = new Sequence();
    Sequence actualCastGreen = new Sequence();

    LeafNode castBlue = new LeafNode(castShieldBlue);
    LeafNode castGreen = new LeafNode(castShieldGreen);
    LeafNode castSelf = new LeafNode(castShieldSelf);
    LeafNode castAnim = new LeafNode(castingAnimation);

    //Heals

    //Attack
    Sequence yellowAttackBoss = new Sequence();

    //Movement Phases
    LeafNode MoveToBoss = new LeafNode(moveToBoss);
    LeafNode ReturnHome = new LeafNode(returnHome);

    //EndTurn

    //Inverters
    Inverter TurnChecker = new Inverter(yellowTurnCheck);

    //object for stats and getters/setters
    public static GenericStats stats = new GenericStats("Yellow", 950, 50);
    public static ParticleSystem particleShooter;

    // Start is called before the first frame update
    void Start()
    {
        //Build the behaviour tree Leaf nodes upwards

        //Shields
        actualCastSelf.addChild(castAnim);
        actualCastSelf.addChild(castSelf);
        actualCastSelf.addChild(EndTurn);
        ShieldSelf.addChild(actualCastSelf);
        DoShield.addChild(ShieldSelf);

        actualCastGreen.addChild(castAnim);
        actualCastGreen.addChild(castGreen);
        actualCastGreen.addChild(EndTurn);
        ShieldGreen.addChild(actualCastGreen);
        DoShield.addChild(ShieldGreen);

        actualCastBlue.addChild(castAnim);
        actualCastBlue.addChild(castBlue);
        actualCastBlue.addChild(EndTurn);
        ShieldBlue.addChild(actualCastBlue);
        DoShield.addChild(ShieldBlue);

        //Heals


        //Attacks


        //Actual Tree Construction
        Yellow.addChild(TurnChecker);
        Yellow.addChild(DoShield);
        Yellow.addChild(EndTurn);
    }

    // Update is called once per frame
    void Update()
    {
        Yellow.run();
    }
}
