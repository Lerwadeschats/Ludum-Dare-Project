using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovements : MonoBehaviour
{
    public float enemyHP;
    public int enemyDamages;
    public int enemySpeed;
    public int enemyStartSpawningWave;

    Rigidbody2D rbEnemy;

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(enemyHP <= 0)
        {
            Death();
        }
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
    }

    public void TakeDamages(float damages)
    {
        enemyHP -= damages;
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
