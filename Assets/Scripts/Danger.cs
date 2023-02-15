using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
    GameObject player;
    private float amount = 20;
    private void Start()
    {
        player = GameObject.Find("StingrayShip");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) player.GetComponent<HAD>().TakeDamage(amount);
    }
}
