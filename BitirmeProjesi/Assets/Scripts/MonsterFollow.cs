using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterFollow : MonoBehaviour
{
    public float monterSpeed;
    public float stoppingDistance;
    private Animator monsterAnimator;
    private Transform target;
    private PlayerControllers playerControllers;
    private MonsterManager MonsterManager;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        monsterAnimator = GetComponent<Animator>();
        playerControllers = GameObject.Find("Player").GetComponent<PlayerControllers>();
        target = playerControllers.transform;
        MonsterManager = GetComponent<MonsterManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MonsterManager.isAlive)
        {
            monsterAnimator.SetFloat("SpeedMonster", Mathf.Abs(monterSpeed));
            //Monster öldüyse karakteri takip etme.


            if (Vector2.Distance(transform.position, target.position) > 3)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, monterSpeed * Time.deltaTime);
                float diffPosition = target.position.x - transform.position.x;
                if (diffPosition > 0)
                {
                    Debug.Log("Karakter canavarın sağında");
                    spriteRenderer.flipX = true;
                }
                else
                {
                    Debug.Log("Karakter canavarın solunda");
                    spriteRenderer.flipX = false;
                }

            }
        }
     
    
       

        
       
    }
}
