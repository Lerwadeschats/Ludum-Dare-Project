using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speedPlayer;
    public int hpPlayer = 12;

    public Rigidbody2D rbPlayer;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    private bool isDashing = false;
    private bool enabledDash = false;
    private bool canDash = true;
    private float dashPower = 50f;
    private float dashCooldown = 1;
    private float dashTime = 0.1f;

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

        if (Input.GetKeyDown(KeyCode.Space) && canDash == true)
        {
            StartCoroutine(Dashing());
        }

    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        rbPlayer.MovePosition(rbPlayer.position + movement * speedPlayer * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rbPlayer.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rbPlayer.rotation = angle;
    }
    public  IEnumerator Dashing()
    {
        Debug.Log("HEY");
        isDashing = true;
        canDash = false;
        rbPlayer.velocity = new Vector2(movement.x * dashPower, movement.y * dashPower);
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
