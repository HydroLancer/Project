using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YellowUpdate : MonoBehaviour
{
    Text HPBox;
    Text TreeBox;

    public static string treeStatus;

    // Start is called before the first frame update
    void Start()
    {
        HPBox = GameObject.Find("YellowHP").GetComponent<Text>();
        TreeBox = GameObject.Find("YellowTreeStatus").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        HPBox.text = "Yellow HP: " + YellowTree.stats.getHP().ToString();
        TreeBox.text = "Tree Status: " + treeStatus;
    }
}
