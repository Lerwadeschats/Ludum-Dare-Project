using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ACTIVE : MonoBehaviour
{
    public GameObject tree;
    bool isActavie;
    void Start()
    {
        tree.SetActive(false);
        isActavie = false;
        print("a");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && isActavie == false)
        {
            print("a");
            tree.SetActive(true);
            isActavie = true;
        }
        if (Input.GetKeyDown(KeyCode.A) && isActavie == true)
        {
            tree.SetActive(false);
            isActavie = false;
        }

    }
}
