using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    Vector3 limits;
    void Update()
    {
        limits = new Vector3(Mathf.Clamp(transform.position.x, -8f, 8f),
           Mathf.Clamp(transform.position.y, -5f, 5f));
        if (this.transform.position != limits) Destroy(this.gameObject);  
    }
}
