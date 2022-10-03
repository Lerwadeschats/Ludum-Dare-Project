using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserk : MonoBehaviour
{
    public bool berserk=false;
    PlayerController speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (berserk == true)
        {
            Debug.Log("berkserkin time");
            berserk = false;
            StartCoroutine(berserking());
        }
        
    }
    public void berserkering()
    {
        berserk = true;
    }
    IEnumerator berserking()
    {
        speed.speedPlayer *= 2;
        yield return new WaitForSeconds(5);
        speed.speedPlayer /= 2;      
        yield return new WaitForSeconds(25);
        berserkering();
    }
}
