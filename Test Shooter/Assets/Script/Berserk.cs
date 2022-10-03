using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserk : MonoBehaviour
{
    public bool berserk=false;
    PlayerController speed;
    GameObject ahhh;
    // Start is called before the first frame update
    void Start()
    {
        speed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        ahhh = GameObject.FindGameObjectWithTag("Hearts");
    }

    // Update is called once per frame
    void Update()
    {
        if (berserk == true)
        {
            Debug.Log("berkserkin time");
            StartCoroutine(berserking());
            berserk = false;
        }

    }
    IEnumerator berserking()
    {
        ahhh.GetComponent<Heart>().enabled = false;
        speed.speedPlayer *= 2;
        yield return new WaitForSeconds(5);
        ahhh.GetComponent<Heart>().enabled = true;
        speed.speedPlayer /= 2;
        yield return new WaitForSeconds(25);
        berserk = true;
    }
}
