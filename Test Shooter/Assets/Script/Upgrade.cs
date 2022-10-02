using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public bool isBuyed = false;
    public bool isLocked = true;

    public List<Upgrade> lookForward;
    public Upgrade dependsOn;
    public Upgrade lockMe;

    public Button button;
    public Image image;

    void Start()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        if (isLocked)
        {
            image.color = Color.black;
        }
    }

    public void Buy()
    {
        isBuyed = true;
        button.enabled = false;
        for(int i = 0; i < lookForward.Count; i++)
        {
            lookForward[i].isLocked = false;
            lookForward[i].button.enabled = true;
            lookForward[i].image.color = Color.white;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
