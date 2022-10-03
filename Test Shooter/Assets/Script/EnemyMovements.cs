using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovements : MonoBehaviour
{
    public float enemyHP;
    public int enemyDamages;
    public int enemySpeed;
    public int enemyStartSpawningWave;
    public float enemyExp;

    public GameObject littleExpPoint;
    public GameObject bigExpPoint;

    WaveSystem waveSys;


    GameObject player;

    Animator anim;

    Heart heart;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        waveSys = GameObject.FindGameObjectWithTag("WaveSystem").GetComponent<WaveSystem>();
        heart = FindObjectOfType<Heart>();
        anim = gameObject.GetComponent<Animator>();
        anim.Play("EnemySide");
    }

    void Update()
    {
        if (enemyHP <= 0)
        {
            
            Death();
        }
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
        gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("hurtbox")   )
        {
            heart.demic();
            player.GetComponent<PlayerController>().hpPlayer -= 1;

        }
    }

    private void FixedUpdate()
    {
        
    }
    public void TakeDamages(float damages)
    {
        enemyHP -= damages;
    }

    public void Death()
    {
        if(enemyExp >= 50)
        {
            for(int i = 0; i < enemyExp/50; i++)
            {
                Instantiate(bigExpPoint, gameObject.transform.position, bigExpPoint.transform.rotation);
            }
        }
        else
        {
            for (int i = 0; i < enemyExp / 10; i++)
            {
                Instantiate(littleExpPoint, gameObject.transform.position, littleExpPoint.transform.rotation);
            }
        }
        waveSys.numberOfEnemies--;
        Destroy(gameObject);
        
    }

    public void AnimationEnemy()
    {
        if ((Mathf.Abs(player.transform.position.x) < Mathf.Abs(player.transform.position.y)) && (player.transform.position.y > 0))
        {
            gameObject.transform.GetComponent<SpriteRenderer>().flipX = false;
            anim.SetBool("EnemyUp", true);
            anim.SetBool("EnemyDown", false);
            anim.SetBool("EnemySide", false);

        }
        else if ((Mathf.Abs(player.transform.position.x) > Mathf.Abs(player.transform.position.y)) && (player.transform.position.x < 0))
        {
            gameObject.transform.GetComponent<SpriteRenderer>().flipX = false;
            anim.SetBool("EnemyUp", false);
            anim.SetBool("EnemyDown", false);
            anim.SetBool("EnemySide", true);
        }
        else if ((Mathf.Abs(player.transform.position.x) < Mathf.Abs(player.transform.position.y)) && (player.transform.position.y < 0))
        {
            gameObject.transform.GetComponent<SpriteRenderer>().flipX = false;
            anim.SetBool("EnemyUp", false);
            anim.SetBool("EnemyDown", true);
            anim.SetBool("EnemySide", false);
        }
        else
        {
            gameObject.transform.GetComponent<SpriteRenderer>().flipX = true;
            anim.SetBool("EnemyUp", false);
            anim.SetBool("EnemyDown", false);
            anim.SetBool("EnemySide", true);
        }
    }

}
