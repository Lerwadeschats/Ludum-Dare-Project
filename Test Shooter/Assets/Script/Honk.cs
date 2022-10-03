using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Honk : MonoBehaviour
{
    int cooldown = 60;
    bool inCooldown=false;
    WaveSystem numberEnemies;
    public int number;
    GameObject[] enemies;
    public AudioClip honkAudio;
    public AudioSource oui;
    private void Start()
    {
        numberEnemies = GameObject.FindGameObjectWithTag("WaveSystem").GetComponent<WaveSystem>();
        
    }
    void Update()
    {
        number = numberEnemies.numberOfEnemies;
        if (Input.GetMouseButtonDown(1) && inCooldown == false)
        {
                        for (int i = 0; i < number; i++)
            {
                numberEnemies.numberOfEnemies--;
            }
            oui.PlayOneShot(honkAudio);
            inCooldown = true;
            DestroyEnemies();
            StartCoroutine(CooldownHonk());

        }

    }
    public void DestroyEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            Destroy(enemy);               
        }
    }
    IEnumerator CooldownHonk()
    {
        yield return new WaitForSeconds(cooldown);
        inCooldown = false;
    }
}
