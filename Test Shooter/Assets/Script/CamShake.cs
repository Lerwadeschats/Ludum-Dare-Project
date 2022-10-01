using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    attack attack; 
    public float time;
    void Start()
    {
        attack = FindObjectOfType<attack>();
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0)
        {
            transform.localPosition = new Vector3(Random.Range(-attack.list[attack.selectedWeapon].camshake, attack.list[attack.selectedWeapon].camshake), Random.Range(-attack.list[attack.selectedWeapon].camshake, attack.list[attack.selectedWeapon].camshake), -10);
            time -= Time.deltaTime;
        }
        else
        {
            transform.localPosition =new Vector3(0,0,-10);
        }
    }
}
