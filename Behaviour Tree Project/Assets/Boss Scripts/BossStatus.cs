using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatus
{
    //properties for the boss, will be expanded
    private int HP = 1000;
    private int damage = 100;

    private int shield = 0;
    //methods for setting HP, etc
   
    public void takeDamage(int value)
    {
        ParticleSystem hitAnim = GameObject.Find("Boss Damaged").GetComponent<ParticleSystem>();
        hitAnim.Play();
        HP -= value;
    }
    public int doDamage()
    {
        return damage;
    }
    public void healSelf(int value)
    {
        HP += value;
    }
    public void shieldBuff(int value)
    {
        shield += value;
    }

    public int getHP()
    {
        return HP;
    }
}
