using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenUpdate : MonoBehaviour
{
    Text HPBox;
    Text TreeBox;
    Text ShieldBox;

    public static string treeStatus;

    // Start is called before the first frame update
    void Start()
    {
        HPBox = GameObject.Find("GreenHP").GetComponent<Text>();
        TreeBox = GameObject.Find("GreenTreeStatus").GetComponent<Text>();
        ShieldBox = GameObject.Find("GreenShieldStatus").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GreenTree.stats.currentHP < (GreenTree.stats.m_maxHP / 100) * 30)
        {
            HPBox.color = new Color(1, 0, 0);
        }
        else
        {
            HPBox.color = new Color(0, 0, 0);
        }
        HPBox.text = "Green HP: " + GreenTree.stats.currentHP.ToString();
        TreeBox.text = "Tree Status: " + treeStatus;
        if (GreenTree.stats.shieldBuffed)
        {
            ShieldBox.color = new Color(0, 1, 0);
        }
        else
        {
            ShieldBox.color = new Color(0, 0, 0);
        }
        ShieldBox.text = "Shield: " + GreenTree.stats.shield.ToString();
    }
}
