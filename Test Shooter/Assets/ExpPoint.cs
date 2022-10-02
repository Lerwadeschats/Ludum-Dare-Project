using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPoint : MonoBehaviour
{
    public float expValue;
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("hurtbox"))
        {
            Debug.Log("Oui");
            player.GetComponent<PlayerController>().xpPlayer += expValue;
            Destroy(gameObject);
        }
    }
}
