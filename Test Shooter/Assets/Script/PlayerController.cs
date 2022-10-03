using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedPlayer;
    public int hpPlayer = 12;
    public float xpPlayer = 0;
    public int lvlPlayer = 1;
    float xpNeeded = 100;
    public int skillPoint=0;

    public GameObject expBar;
    ExpBar exp;

    public Rigidbody2D rbPlayer;
    public Camera cam;
    Animator anim;

    bool isDying;

    Vector2 movement;
    Vector2 mousePos;
    Vector2 playerPos;

    GameObject slasher;

    private bool isDashing = false;
    private bool enabledDash = false;
    private bool canDash = true;
    public float dashPower = 50f;
    public float dashCooldown = 1;
    private float dashTime = 0.1f;

    public WaveSystem waveSystem;

    void Start()
    {
        rbPlayer = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.transform.Find("Sprite").GetComponent<Animator>();
        anim.Play("playerLeft");
        //slasher = gameObject.transform.Find("Slasher").gameObject;
        isDying = false;
        exp = expBar.GetComponent<ExpBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hpPlayer <= 0)
        {
            Death();
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        playerPos = gameObject.transform.position;

        if (Input.GetKeyDown(KeyCode.Space) && canDash == true)
        {
            StartCoroutine(Dashing());
        }
        if(xpPlayer >= xpNeeded)
        {
            GainLevel();
        }
        exp.currentValue = xpPlayer;
        exp.maxValue = xpNeeded;
        exp.levelNumber = lvlPlayer;
        if (!isDying)
        {
            AnimationPlayer(mousePos);
        }
        

    }
    private void FixedUpdate()
    {
        if (!isDying)
        {
            if (isDashing)
            {
                return;
            }
            rbPlayer.MovePosition(rbPlayer.position + movement * speedPlayer * Time.fixedDeltaTime);
        }
    }
    public  IEnumerator Dashing()
    {
        //Debug.Log("HEY");
        isDashing = true;
        canDash = false;
        rbPlayer.velocity = new Vector2(movement.x * dashPower, movement.y * dashPower);
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    public void GainExp(float expGained)
    {
        xpPlayer += expGained;
        
    }
    public void GainLevel()
    {
        lvlPlayer += 1;
        xpPlayer -= xpNeeded;
        xpNeeded = (xpNeeded + 50) * 1.3f;
        skillPoint++;
    }

    public void Death()
    {
        /*Time.timeScale = 0;*/
        Destroy(gameObject.transform.GetChild(1).GetComponent<alors>());
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        isDying = true;
        anim.SetBool("Dead", true);
        waveSystem.EndGame();
    }
    public void AnimationPlayer(Vector2 mousePos)
    {
        if (gameObject.GetComponent<Berserk>().isBerserking)
        {
            if ((Mathf.Abs(mousePos.x - playerPos.x) < Mathf.Abs(mousePos.y - playerPos.y)) && (mousePos.y - playerPos.y > 0))
            {
                //Debug.Log("Up");
                anim.SetBool("bUp", true);
                anim.SetBool("bDown", false);
                anim.SetBool("bRight", false);
                anim.SetBool("bLeft", false);
                anim.SetBool("Up", false);
                anim.SetBool("Down", false);
                anim.SetBool("Right", false);
                anim.SetBool("Left", false);


            }
            else if ((Mathf.Abs(mousePos.x - playerPos.x) > Mathf.Abs(mousePos.y - playerPos.y)) && (mousePos.x - playerPos.x < 0))
            {
                //Debug.Log("Left");
                anim.SetBool("bUp", false);
                anim.SetBool("bDown", false);
                anim.SetBool("bRight", false);
                anim.SetBool("bLeft", true);
                anim.SetBool("Up", false);
                anim.SetBool("Down", false);
                anim.SetBool("Right", false);
                anim.SetBool("Left", false);

            }
            else if ((Mathf.Abs(mousePos.x - playerPos.x) < Mathf.Abs(mousePos.y - playerPos.y)) && (mousePos.y - playerPos.y < 0))
            {
                //Debug.Log("Down");
                anim.SetBool("bUp", false);
                anim.SetBool("bDown", true);
                anim.SetBool("bRight", false);
                anim.SetBool("bLeft", false);
                anim.SetBool("Up", false);
                anim.SetBool("Down", false);
                anim.SetBool("Right", false);
                anim.SetBool("Left", false);

            }
            else
            {
                //Debug.Log("Right");
                anim.SetBool("bUp", false);
                anim.SetBool("bDown", false);
                anim.SetBool("bRight", true);
                anim.SetBool("bLeft", false);
                anim.SetBool("Up", false);
                anim.SetBool("Down", false);
                anim.SetBool("Right", false);
                anim.SetBool("Left", false);

            }
        }
        else
        {
            if ((Mathf.Abs(mousePos.x - playerPos.x) < Mathf.Abs(mousePos.y - playerPos.y)) && (mousePos.y - playerPos.y > 0))
            {
                //Debug.Log("Up");
                anim.SetBool("bUp", false);
                anim.SetBool("bDown", false);
                anim.SetBool("bRight", false);
                anim.SetBool("bLeft", false);
                anim.SetBool("Up", true);
                anim.SetBool("Down", false);
                anim.SetBool("Right", false);
                anim.SetBool("Left", false);


            }
            else if ((Mathf.Abs(mousePos.x - playerPos.x) > Mathf.Abs(mousePos.y - playerPos.y)) && (mousePos.x - playerPos.x < 0))
            {
                //Debug.Log("Left");
                anim.SetBool("bUp", false);
                anim.SetBool("bDown", false);
                anim.SetBool("bRight", false);
                anim.SetBool("bLeft", false);
                anim.SetBool("Up", false);
                anim.SetBool("Down", false);
                anim.SetBool("Right", false);
                anim.SetBool("Left", true);

            }
            else if ((Mathf.Abs(mousePos.x - playerPos.x) < Mathf.Abs(mousePos.y - playerPos.y)) && (mousePos.y - playerPos.y < 0))
            {
                //Debug.Log("Down");
                anim.SetBool("bUp", false);
                anim.SetBool("bDown", false);
                anim.SetBool("bRight", false);
                anim.SetBool("bLeft", false);
                anim.SetBool("Up", false);
                anim.SetBool("Down", true);
                anim.SetBool("Right", false);
                anim.SetBool("Left", false);

            }
            else
            {
                //Debug.Log("Right");
                anim.SetBool("bUp", false);
                anim.SetBool("bDown", false);
                anim.SetBool("bRight", false);
                anim.SetBool("bLeft", false);
                anim.SetBool("Up", false);
                anim.SetBool("Down", false);
                anim.SetBool("Right", true);
                anim.SetBool("Left", false);

            }
        }
        
    }
}
