using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

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
            print(tree.active);
            tree.SetActive(true);
            Time.timeScale = 0;
            print(tree.active);
            isActavie = true;
        }
        else if (Input.GetKeyDown(KeyCode.A) && isActavie == true)
        {
            Time.timeScale = 1;
            tree.SetActive(false);
            isActavie = false;
        }
        //PD
    }
}
