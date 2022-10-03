using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPoint : MonoBehaviour
{
    public float expValue;
    GameObject player;

    public Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position, transform.position) <= 15)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("hurtbox"))
        {
            player.GetComponent<PlayerController>().xpPlayer += expValue;
            Destroy(gameObject);
        }
    }
}
