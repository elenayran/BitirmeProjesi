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


    public Transform monsterAttackPoint;
    public float monsterAttackRange = 0.5f;
    public LayerMask playerLayers;
    public int monsterAttackDamage = 40;
    public float monsterAttackRate = 2f;
    float monsterNextAttackTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerControllers = FindObjectOfType<PlayerControllers>();
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
                    spriteRenderer.flipX = true;
                }
                else
                {
                    spriteRenderer.flipX = false;
                }

            }
            if (Vector2.Distance(transform.position, playerControllers.transform.position) < 10)
            {
                Attack();

            }
        }

        
    }

    void Attack()
    {     

        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(monsterAttackPoint.position, monsterAttackRange, playerLayers);
        Debug.Log(hitPlayer.Length);
        foreach (Collider2D player in hitPlayer)
        {
            PlayerManager playerManager = player.GetComponent<PlayerManager>();
            if (playerManager != null && playerManager.isAlive)
            {
                monsterAnimator.SetTrigger("AttackMonster");
                player.GetComponent<PlayerManager>().PlayerTakeDamage(monsterAttackDamage);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {

        if (monsterAttackPoint == null)
        {
            return;

        }
        Gizmos.DrawWireSphere(monsterAttackPoint.position, monsterAttackRange);
    }
}
