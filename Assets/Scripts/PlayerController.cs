using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //-Movement Var-
    public float playerSpeed = 8f;
    Vector3 direction;
    public Rigidbody2D rb2d;

    //-Shooting Var-
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //MOVEMENT INPUT:
        direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        //SCREEEN BOUNDS
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7.5f, 7.5f),
            Mathf.Clamp(transform.position.y, -4f, 4f));
        
        Skills();
    }
    private void FixedUpdate()
    {
        //SHIP MOVEMENT:
        Vector3 position = rb2d.position;
        position = position + direction * playerSpeed * Time.deltaTime;
        rb2d.MovePosition(position);   
    }
    public void Skills()
    {
        //SKILLS:
        //-Turbo-
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = 10;

        }
        else playerSpeed = 8;
        
        //-Shooting-
        //-SoundWave-     
    }
}
