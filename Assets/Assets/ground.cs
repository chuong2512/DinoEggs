using System.Collections;
using System.Collections.Generic;
using ChuongCustom;
using UnityEngine;

public class ground : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D.velocity = Vector2.left * GameManager.Instance.Speed; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
