using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float bgSpeed;
    [SerializeField] Renderer bgRnd;

    void Update()
    {
        bgRnd.material.mainTextureOffset += new Vector2(0,bgSpeed * Time.deltaTime);   
    }
}
