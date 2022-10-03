using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpBar : MonoBehaviour
{

    public GameObject level;
    TextMeshProUGUI levelText;
    public GameObject exp;
    TextMeshProUGUI expText;


    Slider slider;


    public float maxValue;
    public float currentValue;
    public int levelNumber;
    void Start()
    {
        maxValue = 100;
        currentValue = 0;
        slider = gameObject.GetComponent<Slider>();
        levelText = level.GetComponent<TextMeshProUGUI>();
        expText = exp.GetComponent<TextMeshProUGUI>();
    }

    
    void Update()
    {
        slider.value = currentValue;
        slider.maxValue = maxValue;
        levelText.text = "Lvl " + levelNumber;
        expText.text = currentValue + " / " + maxValue;
    }
}
