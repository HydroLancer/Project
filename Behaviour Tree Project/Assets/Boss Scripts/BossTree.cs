using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossTree : MonoBehaviour
{
    ///////////////Boss' Tree///////////////////////////
    Selector Boss = new Selector();

    static LeafNode.methodDelegate bossMove = new LeafNode.methodDelegate(BossActions.attackEnemy);
    static LeafNode.methodDelegate bossHome = new LeafNode.methodDelegate(BossActions.BossToHome);
    static LeafNode.methodDelegate bossCheckTurn = new LeafNode.methodDelegate(BossActions.turnCheck);
    static LeafNode.methodDelegate bossEndTurn = new LeafNode.methodDelegate(BossActions.endTurn);
    static LeafNode.methodDelegate bossTarget = new LeafNode.methodDelegate(BossActions.TargetEnemy);

    //////////////Boss' Tree///////////////////////////
    static LeafNode bossTurnCheck = new LeafNode(bossCheckTurn);
    Sequence BossAttackEnemy = new Sequence();
    LeafNode BossTarget = new LeafNode(bossTarget);
    LeafNode BossMoveToEnemy = new LeafNode(bossMove);
    LeafNode BossReturnHome = new LeafNode(bossHome);
    LeafNode BossturnEnd = new LeafNode(bossEndTurn);

    //Inverter for turn checking & More
    Inverter BossTurnCheker = new Inverter(bossTurnCheck);

    //object to update stats
    public static BossStatus stats = new BossStatus();

    //NavMesh Agent
    static public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        Boss.addChild(BossTurnCheker);
        BossAttackEnemy.addChild(BossTarget);
        BossAttackEnemy.addChild(BossMoveToEnemy);
        BossAttackEnemy.addChild(BossReturnHome);
        BossAttackEnemy.addChild(BossturnEnd);
        Boss.addChild(BossAttackEnemy);
    }

    // Update is called once per frame
    void Update()
    {
        Boss.run();
    }
}
