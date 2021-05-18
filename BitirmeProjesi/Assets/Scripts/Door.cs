﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool IsOpen;
    public Animator animator;

    [SerializeField] GameObject doorMusic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsOpen && collision.gameObject.tag == "Player")
        {
            Debug.Log("Kapı açık ve karakter içinden geçebilir.");

            animator.SetTrigger("DoorOpen");

            //GameObject.Find("Sound Controller").GetComponent<AudioSource>().PlayOneShot(doorMusic);
        }
    }
}
