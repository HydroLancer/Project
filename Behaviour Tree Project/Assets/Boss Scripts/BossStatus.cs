using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatus
{
    //properties for the boss, will be expanded
    private int HP = 1000;
    private int baseDmg = 100;

    private int shield = 0;
    //methods for setting HP, etc
   
    public void takeDamage(int value)
    {
        HP -= value;
    }
    void healSelf(int value)
    {
        HP += value;
    }
    void shieldBuff(int value)
    {
        shield += value;
    }

    public int returnHP()
    {
        return HP;
    }
}
