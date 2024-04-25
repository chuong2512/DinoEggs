using System;
using System.Collections;
using System.Collections.Generic;
using ChuongCustom;
using UnityEngine;

public class Trung : MonoBehaviour
{
    public SpriteRenderer _Sprite;
    
    public Rigidbody2D rigidbody2D;

    private void Start()
    {
        _Sprite.sprite = SkinDataManager.Instance.CurrentSkin;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("trung va cham");
        rigidbody2D.constraints = RigidbodyConstraints2D.None;
    }

    public void Bay()
    {
        rigidbody2D.constraints = RigidbodyConstraints2D.None;
    }
}
