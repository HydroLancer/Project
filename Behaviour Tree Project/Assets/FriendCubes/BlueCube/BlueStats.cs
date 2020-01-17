using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueStats
{
    private int maxHP = 1200;
    private int currentHP = 1200;
    private int shield = 0;
    private int damage = 150;

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
        currentHP += value;
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

    public void getHealed(int value)
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

    public void getShield(int value)
    {
        shield += value;
        shieldBuffed = true;
    }

    public void getDamageBuff(int value)
    {
        damage += value;
        damageBuffed = true;
    }
}
