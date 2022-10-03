using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryWeapon : MonoBehaviour
{
    public List<attack.Arme> weapons = new List<attack.Arme>();
    public GameObject[] weaponsSlots;
    public int weaponUsedID;
    public float reloadTimeLazer;
    attack attakc;


    void Start()
    {
        attakc = GameObject.FindGameObjectWithTag("Player").GetComponent<attack>();

    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < attakc.list.Count; i++)
        {
            if (attakc.list[i].isObtained && !attakc.list[i].isAlreadyInInventory)
            {
                weapons[attakc.list[i].ID] = attakc.list[i];
            }
        }
        for (int i = 0; i < weapons.Count; i++)
        {
            if (attakc.list[i].isAlreadyInInventory)
            {
                weaponsSlots[i].transform.GetChild(2).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                weaponsSlots[i].transform.GetChild(2).GetComponent<Image>().sprite = weapons[i].sprite;
            }
            else
            {
                weaponsSlots[i].transform.GetChild(2).GetComponent<Image>().color = new Color(1, 1, 1, 0);
            }
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
        /*weaponsSlots[2].transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = reloadTimeLazer.ToString();*/

    }

    /*public void UsingLazer()
    {
        weaponsSlots[2].transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.SetActive(true);
        StartCoroutine(CooldownLazer());
    }

    IEnumerator CooldownLazer()
    {
        weaponsSlots[2].transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        reloadTimeLazer--;

    }*/


}
