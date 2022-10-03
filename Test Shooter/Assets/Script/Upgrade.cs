using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Upgrade : MonoBehaviour
{
    public bool isBuyed = false;
    public bool isLocked = true;
    private PlayerController skillpoint;
    private attack attakc;
    public GameObject heart;
    public Image coeur;

    public List<Upgrade> lookForward;
    public Upgrade dependsOn;
    public Upgrade lockMe;

    public Button button;
    public Image image;
    public Berserk berserker;
    public Honk honker;

    
    void Start()
    {
        attakc = GameObject.FindGameObjectWithTag("Player").GetComponent<attack>();
        skillpoint = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        if (isLocked)
        {
            image.color = Color.black;
        }
        
    }

    public void Buy()
    {
        if (skillpoint.skillPoint > 0)
        {
            isBuyed = true;
            button.enabled = false;
            for (int i = 0; i < lookForward.Count; i++)
            {
                lookForward[i].isLocked = false;
                lookForward[i].button.enabled = true;
                lookForward[i].image.color = Color.white;

            }
            skillpoint.skillPoint--;
        }
        
    }
    public void tronco()
    {
        if (attakc.Cscount == 0)
        {
            attakc.csAAA.transform.localScale = new Vector3(12, 12, 12);
            print(attakc.csAAA.transform.localScale.z);
            attakc.list[1].damage += 15;

        }
        else if (attakc.Cscount == 1)
        {
            attakc.csAAA.transform.localScale = new Vector3(20, 20, 20);
            attakc.list[1].damage += 15;

        }
        attakc.Cscount += 1;
    }
    public void shotgun()
    {
        print(skillpoint.skillPoint);
        if (isBuyed)
        {
            if (attakc.sgcount == 0)
            {
                attakc.list[0].isObtained = true;
                attakc.list[0].bulletShoted = 3;
                attakc.list[0].damage = 3;
                attakc.list[0].spreadness = 5;
                attakc.list[0].camshake = 0.25f;
            }
            else if (attakc.sgcount == 1)
            {
                attakc.list[0].bulletShoted = 7;
                attakc.list[0].damage = 5;
                attakc.list[0].spreadness = 15;
                attakc.list[0].camshake = 1f;
            }
            else if (attakc.sgcount == 2)
            {
                attakc.list[0].bulletShoted = 30;
                attakc.list[0].damage = 10;
                attakc.list[0].spreadness = 30;
                attakc.list[0].camshake = 2f;
            }
            attakc.sgcount += 1;
            print(attakc.sgcount);
        }

        
    }
    public void Ray()
    {
        if (isBuyed)
        {
            if (attakc.WallCount == 0)
            {
                attakc.list[2].isObtained = true;
                attakc.list[2].bulletShoted = 1;
            }
            else
            {
                attakc.list[2].speed = 30;
                attakc.list[2].reoladTime = 8;
            }
            attakc.WallCount += 1;
        }
    }
    public void setDash(float power)
    {
        if (isBuyed)
        {
            skillpoint.dashPower = power;
        }
    }
    public void setDASHCD(float CD)
    {
        if (isBuyed)
        {
            skillpoint.dashCooldown = CD;
        }
    }
    public void setSpeed(float sped)
    {
        if (isBuyed)
        {
            skillpoint.speedPlayer += sped;
        }
    }
    public void setBerserk(bool berserk)
    {
        if (isBuyed)
        {
            berserker.berserk = berserk;
        }
    }
    public void setHonk(bool honk)
    {
        if (isBuyed)
        {
            honker.honkEnabled = honk;
        }
    }
    public void AddLife()
    {
        if (isBuyed)
        {
            skillpoint.hpPlayer += 2;
            var go = Instantiate(coeur, Vector3.zero, Quaternion.identity);
            print(go.rectTransform.position.y);
            go.rectTransform.parent = heart.transform;
            print(go.rectTransform.position.y);
            go.rectTransform.position = new Vector3(80 * heart.transform.childCount - 30, 1030);
        }
    }
public void Lock()
    {
        if (isBuyed)
        {
            image.color = Color.black;
            isLocked = true;
            button.enabled = false;
        }
    }

}
