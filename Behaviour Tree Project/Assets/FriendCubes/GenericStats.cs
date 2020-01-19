using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericStats
{
    //Parameters per NPC

    private string m_name { get; set; }
    private int m_maxHP { get; set; }
    public int currentHP { get; set; }
    private int shield { get; set; }
    private int m_damage { get; set; }
    private bool shieldBuffed { get; set; }
    private bool damageBuffed { get; set; }

    public GenericStats(string name, int maxHP, int damage)
    {
        m_name = name;
        m_maxHP = maxHP;
        m_damage = damage;

        shield = 0;
        currentHP = maxHP;

        shieldBuffed = false;
        damageBuffed = false;

    }

    //Checks to see if the NPC has a shield, and if it does, takes the damage off it instead before taking off currentHP
    public void TakeDamage(int value)
    {
        int remainder;
        if (shieldBuffed)
        {
            if (value > shield)
            {
                remainder = value - shield;
                shield = 0;
                currentHP -= remainder;
                shieldBuffed = false;
                return;
            }
            else
            {
                shield -= value;
                return;
            }
        }
        currentHP -= value;
        return;
    }

    public int DoDamage()
    {
        return m_damage;
    }

    //Restores HP, but makes sure it can't go above the maximum
    public void RecoverHP(int value)
    {
        if (currentHP + value > m_maxHP)
        {
            currentHP = m_maxHP;
        }
        else
        {
            currentHP += value;
        }
    }

    //When buffed by a shield, sets the shield up and applies the bool to ensure it can't be applied over and over
    public void SetShield(int value)
    {
        if (!shieldBuffed)
        {
            shield += value;
            shieldBuffed = true;
        }
    }

    //When buffed, sets the damage up and applies the bool to ensure it can't be applied over and over - 20% Damage increase
    public void SetDamageUp()
    {
        if (!damageBuffed)
        {
            m_damage += (m_damage / 100) * 20;
            damageBuffed = true;
        }
    }
}
