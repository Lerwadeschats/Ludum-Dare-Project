using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovements : MonoBehaviour
{
    public float enemyHP;
    public int enemyDamages;
    public int enemySpeed;
    public int enemyStartSpawningWave;

    WaveSystem waveSys;

    Rigidbody2D rbEnemy;

    GameObject player;

    Heart heart;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        waveSys = GameObject.FindGameObjectWithTag("WaveSystem").GetComponent<WaveSystem>();
        heart = FindObjectOfType<Heart>();
    }

    void Update()
    {
        if(enemyHP <= 0)
        {
            
            Death();
        }
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("hurtbox")   )
        {
            heart.demic();
            player.GetComponent<PlayerController>().hpPlayer -= 1;

        }
    }
    public void TakeDamages(float damages)
    {
        enemyHP -= damages;
    }

    public void Death()
    {
        waveSys.numberOfEnemies--;
        Destroy(gameObject);
        
    }

}
