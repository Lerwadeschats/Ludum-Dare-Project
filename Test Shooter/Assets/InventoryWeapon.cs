using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWeapon : MonoBehaviour
{
    public List<attack.Arme> weapons = new List<attack.Arme>();
    public GameObject[] weaponsSlots;
    public int weaponUsedID;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            weaponsSlots[i].transform.GetChild(3).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            weaponsSlots[i].transform.GetChild(3).GetComponent<Image>().sprite = weapons[i].sprite;
        }

        for(int i = 0; i < weapons.Count; i++)
        {
            if(weapons[i] != null && i == weaponUsedID)
            {
                weaponsSlots[i].transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                weaponsSlots[i].transform.GetChild(1).gameObject.SetActive(false);
            }
        }
        

    }

    
}
