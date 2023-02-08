using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //-Movement Var-
    float playerSpeed = 8f;
    Vector3 direction;
    [SerializeField] Rigidbody2D rb2d;

    //-Shooting Var-
    [SerializeField] List<GameObject> bulletPH; 
    public GameObject bullet;
    bool alreadyCast;
    float bulletSpeed = 10f;
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
        if (Input.GetKey(KeyCode.Space)) 
        {
            if (!alreadyCast) 
            {
                Shoot();
                Invoke(nameof(ResetCasting), 0.1f);
            }      
        }
        //-SoundWave-     
    }

    public void ResetCasting() => alreadyCast = false;
    public void Shoot() 
    {
        foreach (GameObject ph in bulletPH)
        {
            var pellet = Instantiate(bullet, ph.transform.position, ph.transform.rotation);    
            Rigidbody2D bulletRb = pellet.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(ph.transform.up * bulletSpeed, ForceMode2D.Impulse);
        }
        alreadyCast = true;
    }
}
