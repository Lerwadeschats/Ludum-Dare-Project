using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speedPlayer;
    public int hpPlayer = 20;

    public Rigidbody2D rbPlayer;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    void Start()
    {
        rbPlayer = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
    }
    private void FixedUpdate()
    {
        rbPlayer.MovePosition(rbPlayer.position + movement * speedPlayer * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rbPlayer.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rbPlayer.rotation = angle;
    }
}
