using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueUpdate : MonoBehaviour
{
    Text HPBox;
    Text TreeBox;

    public static string treeStatus;

    // Start is called before the first frame update
    void Start()
    {
        HPBox = GameObject.Find("BlueHP").GetComponent<Text>();
        TreeBox = GameObject.Find("BlueTreeStatus").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        HPBox.text = "Blue HP: " + BlueTree.stats.getHP().ToString();
        TreeBox.text = "Tree Status: " + treeStatus;
    }
}
