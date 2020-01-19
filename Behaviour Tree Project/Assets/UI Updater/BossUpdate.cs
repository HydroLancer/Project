using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUpdate : MonoBehaviour
{
    Text HPBox;
    Text TreeBox;

    public static string treeStatus;

    // Start is called before the first frame update
    void Start()
    {
        HPBox = GameObject.Find("BossHP").GetComponent<Text>();
        TreeBox = GameObject.Find("BossTreeStatus").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        HPBox.text = "Boss HP: " + BossTree.stats.currentHP.ToString();
        TreeBox.text = "Tree Status: " + treeStatus;
    }
}
