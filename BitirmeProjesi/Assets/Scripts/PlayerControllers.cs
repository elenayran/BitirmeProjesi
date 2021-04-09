using System.Collections;
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

    public float distance;
    public LayerMask WhatIsLadder;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage=40;
    public float attackRate = 2f;
    float nextAttactTime= 0f;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        defaultLocalScale = transform.localScale;
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
             Debug.Log("yukarı ok tuşuna basıldı.");
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
            enemy.GetComponent<MonsterManager>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void FixedUpdate()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, WhatIsLadder);
    }
}
