using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YellowUpdate : MonoBehaviour
{
    Text HPBox;
    Text TreeBox;
    Text ShieldBox;

    public static string treeStatus;

    // Start is called before the first frame update
    void Start()
    {
        HPBox = GameObject.Find("YellowHP").GetComponent<Text>();
        TreeBox = GameObject.Find("YellowTreeStatus").GetComponent<Text>();
        ShieldBox = GameObject.Find("YellowShieldStatus").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (YellowTree.stats.currentHP < (YellowTree.stats.m_maxHP / 100) * 30)
        {
            HPBox.color = new Color(1, 0, 0);
        }
        else
        {
            HPBox.color = new Color(0, 0, 0);
        }
        HPBox.text = "Yellow HP: " + YellowTree.stats.currentHP.ToString();
        TreeBox.text = "Tree Status: " + treeStatus;
        if (YellowTree.stats.shieldBuffed)
        {
            ShieldBox.color = new Color(0, 1, 0);
        }
        else
        {
            ShieldBox.color = new Color(0, 0, 0);
        }
        ShieldBox.text = "Shield: " + YellowTree.stats.shield.ToString();
    }
}
