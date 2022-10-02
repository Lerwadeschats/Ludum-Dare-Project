using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alors : MonoBehaviour
{
    Vector2 mousePos;
    public Camera cam;
    public Rigidbody2D rbPlayer;


    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.parent.position;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - rbPlayer.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rbPlayer.rotation = angle;
    }
}
