using System.Collections;
using System.Collections.Generic;
using ChuongCustom;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    public Rigidbody2D Rigidbody2D;
    private bool play;

    public Trung trung;
    public Trung[] eggs;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Play()
    {
        play = true;
    }

    public float speed = 2;

    public float high;


    void Update()
    {
        if (play && GameManager.Instance.currentState == State.Playing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SpawnEgg();
            }
        }
    }

    private void SpawnEgg()
    {
        var pos = transform.position;
        transform.position += Vector3.up * high;

        Instantiate(trung, pos, Quaternion.identity);
        
        MasterAudioManager.Play2DSfx(AudioConst.Jump);
    }
}