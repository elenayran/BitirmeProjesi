﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    private float mySpeedX;
    [SerializeField] float speed;
    [SerializeField] float jumpPower;
   
    private Rigidbody2D myBody;
    private Vector3 defaultLocalScale;
    public bool onGround;
    private bool canDoubleJump;
    private Animator myAnimator;

    private float inputVertical;
    public float distance;
    public LayerMask WhatIsLadder;
    private bool isClimbing;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage=20;
    public float attackRate = 2f;
    float nextAttactTime= 0f;


    private PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        defaultLocalScale = transform.localScale;
        playerManager = GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetAxis("Horizontal"));
        mySpeedX = Input.GetAxis("Horizontal");
        myAnimator.SetFloat("Speed", Mathf.Abs(mySpeedX));
        myBody.velocity = new Vector2(mySpeedX * speed, myBody.velocity.y);
       
        #region playerın sağ ve sol hareket yönine göre dönmesi
        if (mySpeedX > 0)
        {
            transform.localScale = new Vector3(defaultLocalScale.x, defaultLocalScale.y, defaultLocalScale.z);
        }
        else if (mySpeedX < 0)
        {
            transform.localScale = new Vector3(-defaultLocalScale.x, defaultLocalScale.y, defaultLocalScale.z);
        }

        #endregion

        #region playerın zıplamasının kontrol edilmesi
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (onGround == true)
            {
                myBody.velocity = new Vector2(myBody.velocity.x, jumpPower);
                canDoubleJump = true;
                myAnimator.SetTrigger("Jump");
            }
            else
            {
                if (canDoubleJump == true)
                {
                    myBody.velocity = new Vector2(myBody.velocity.x, jumpPower);
                    canDoubleJump = false;
                }
            }

        }
        #endregion

        #region attack kontrolü


        if (Time.time>=nextAttactTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttactTime = Time.time + 1f / attackRange;
            }

        }
       
        #endregion



    }
    
    void Attack()
    {
        myAnimator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            MonsterManager _monsterManager = enemy.GetComponent<MonsterManager>();
            if (_monsterManager.isAlive)
            {
                enemy.GetComponent<MonsterManager>().TakeDamage(attackDamage);
            }            
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Traps")
        {
            playerManager.PlayerTakeDamage(attackDamage);
            Debug.Log("HASAR ALINDI");

        }

    }
}
