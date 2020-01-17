using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenStats
{
    private int maxHP = 1000;
    private int currentHP = 1000;
    private int shield = 0;
    private int damage = 100;
    private int damageBuffOutput = 100;

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
    public void buffSelf()
    {
        damage += damageBuffOutput;
        damageBuffed = true;
    }
    public int buffTarget()
    {
        return damageBuffOutput;
    }
}
