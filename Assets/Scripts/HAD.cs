using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HAD : MonoBehaviour
{
    public float life = 100;
    void Update()
    {
        if (life > 100) life = 100;
        else if (life < 0) life = 0;
    }

    public void TakeDamage(float amount) => life -= amount;
    public void RepairDamage(float amount) => life += amount;
}
