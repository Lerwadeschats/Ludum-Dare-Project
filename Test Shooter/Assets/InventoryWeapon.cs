using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWeapon : MonoBehaviour
{
    public List<attack.Arme> weapons = new List<attack.Arme>();
    public GameObject[] weaponsSlots;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            weaponsSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = weapons[i].sprite;
        }
    }

    
}
