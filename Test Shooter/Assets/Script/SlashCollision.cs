using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashCollision : MonoBehaviour
{
    public float damages;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.transform.Find("Slash").tag == "Enemy")
        {
            
            collision.gameObject.transform.Find("Slash").GetComponent<EnemyMovements>().TakeDamages(damages);
        }
    }
}
