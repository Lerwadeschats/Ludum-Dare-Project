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
        }
        else if (attakc.Cscount == 1)
        {
            attakc.csAAA.transform.localScale = new Vector3(20, 20, 20);
        }
        attakc.Cscount += 1;
    }
    public void shotgun()
    {
        if (attakc.sgcount == 0)
        {
            attakc.list[0].isObtained = true;
            attakc.list[0].bulletShoted = 3;
            attakc.list[0].spreadness = 5;
            attakc.list[0].camshake = 0.25f;
        }
        else if (attakc.sgcount == 1)
        {
            attakc.list[0].bulletShoted = 7;
            attakc.list[0].spreadness = 15;
            attakc.list[0].camshake = 1f;
        }
        else
        {
            attakc.list[0].bulletShoted = 30;
            attakc.list[0].spreadness = 30;
            attakc.list[0].camshake = 2f;
        }

        attakc.sgcount += 1;
        print(attakc.sgcount);
    }
    public void Ray()
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
    public void setDash(float power)
    {
        skillpoint.dashPower = power;
    }
    public void setDASHCD(float CD)
    {
        skillpoint.dashCooldown = CD;
    }
    public void setSpeed(float sped)
    {
        skillpoint.speedPlayer += sped;
    }
    public void setBerserk(bool berserk)
    {
        berserker.berserk = berserk;
    }
    public void setHonk(bool honk)
    {
        honker.honkEnabled = honk;
    }
    public void AddLife()
    {
        skillpoint.hpPlayer += 2;
        var go = Instantiate(coeur, Vector3.zero, Quaternion.identity);
        print(go.rectTransform.position.y);
        go.rectTransform.parent = heart.transform;
        print(go.rectTransform.position.y);
        go.rectTransform.position = new Vector3(80 * heart.transform.childCount - 30, 1030);
    }
public void Lock()
    {
        image.color = Color.black;
        isLocked = true;
        button.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
