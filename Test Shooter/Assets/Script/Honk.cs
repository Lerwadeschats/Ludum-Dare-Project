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
    bool canBeDestroyed;
    private void Start()
    {
        numberEnemies = GameObject.FindGameObjectWithTag("WaveSystem").GetComponent<WaveSystem>();
        canBeDestroyed = false;
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
            enemy.GetComponent<Animator>().SetBool("EnemyDeath", true);
            enemy.GetComponent<EnemyMovements>().enemySpeed = 0;
            enemy.GetComponent<Rigidbody2D>().isKinematic = true;
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            StartCoroutine(CountdownDeath());
            if (canBeDestroyed)
            {
                Destroy(enemy);
            }
                             
        }
    }
    IEnumerator CooldownHonk()
    {
        yield return new WaitForSeconds(cooldown);
        inCooldown = false;
    }

    IEnumerator CountdownDeath()
    {
        yield return new WaitForSeconds(2f);
        canBeDestroyed = true;
    }
}
