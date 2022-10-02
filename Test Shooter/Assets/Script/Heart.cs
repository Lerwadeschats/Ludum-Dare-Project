using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public PlayerController player;
    public Sprite demie;
    // Start is called before the first frame update 
    void Start()
    {

    }
    public void demic()
    {
        print("itsme");
        if (player.hpPlayer == 0)
        {
            //END GAME 
        }
        if (player.hpPlayer % 2 == 0)
        {
            transform.GetChild(transform.childCount - 1).GetComponent<Image>().sprite = demie;
            print("luigi");
        }
        else
        {
            Destroy(transform.GetChild(transform.childCount - 1).gameObject);
            print("mario");
        }
    }
    // Update is called once per frame 
    void Update()
    {

    }
}
