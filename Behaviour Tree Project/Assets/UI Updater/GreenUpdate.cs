using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenUpdate : MonoBehaviour
{
    Text HPBox;
    Text TreeBox;

    public static string treeStatus;

    // Start is called before the first frame update
    void Start()
    {
        HPBox = GameObject.Find("GreenHP").GetComponent<Text>();
        TreeBox = GameObject.Find("GreenTreeStatus").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        HPBox.text = "Green HP: " + GreenTree.stats.getHP().ToString();
        TreeBox.text = "Tree Status: " + treeStatus;
    }
}
