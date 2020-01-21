using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueUpdate : MonoBehaviour
{
    Text HPBox;
    Text TreeBox;
    Text ShieldBox;

    public static string treeStatus;

    // Start is called before the first frame update
    void Start()
    {
        HPBox = GameObject.Find("BlueHP").GetComponent<Text>();
        TreeBox = GameObject.Find("BlueTreeStatus").GetComponent<Text>();
        ShieldBox = GameObject.Find("BlueShieldStatus").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BlueTree.stats.currentHP < (BlueTree.stats.m_maxHP / 100) * 30)
        {
            HPBox.color = new Color(1, 0, 0);
        }
        else
        {
            HPBox.color = new Color(0, 0, 0);
        }
        HPBox.text = "Blue HP: " + BlueTree.stats.currentHP.ToString();
        TreeBox.text = "Tree Status: " + treeStatus;
        if (BlueTree.stats.shieldBuffed)
        {
            ShieldBox.color = new Color(0, 1, 0);
        }
        else
        {
            ShieldBox.color = new Color(0, 0, 0);
        }
        ShieldBox.text = "Shield: " + BlueTree.stats.shield.ToString();
    }
}
