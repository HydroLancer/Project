using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowStats
{
    private int maxHP = 950;
    private int currentHP = 950;
    private int shield = 0;
    private int damage = 50;
    private int healOutput = 200;
    private int shieldOutput = 150;

    private bool shieldBuffed = false;
    private bool damageBuffed = false;

    public int getHP()
    {
        return currentHP;
    }

    public void damageHP(int value)
    {
        currentHP -= value;
    }

    public void healHP(int value)
    {
        if (currentHP + value > maxHP)
        {
            currentHP = maxHP;
        }
        else
        {
            currentHP += value;
        }
    }

    public int doDamage()
    {
        return damage;
    }
    public void takeDamage(int value)
    {
        int remainder;

        if (shield > 0)
        {
            if (value > shield)
            {
                remainder = value - shield;
                shield = 0;
                shieldBuffed = false;
                currentHP -= remainder;
            }
            else
            {
                shield -= value;
            }
        }
        else
        {
            currentHP -= value;
        }
    }

    public int healTarget()
    {
        return healOutput;
    }

    public int shieldTarget()
    {
        return shieldOutput;
    }

    public void shieldSelf()
    {
        shield = shieldOutput;
        shieldBuffed = true;
    }

    public void healSelf()
    {
        currentHP += healOutput;
    }

    public void getDamageBuffed(int value)
    {
        damage += value;
        damageBuffed = true;
    }

    public bool checkBuff()
    {
        return damageBuffed;
    }
}
