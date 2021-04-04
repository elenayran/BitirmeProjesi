using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
   [SerializeField] bool onGround;
    private float width;
    private Animator monster2Animator;
    [SerializeField] float monter2Speed;
    private Rigidbody2D myBody;
    [SerializeField] LayerMask engel;
    private static int totalMonsterNumber = 0;


    public Transform monster2AttackPoint;
    public float monster2AttackRange = 0.5f;
    public LayerMask playerLayers;
    private PlayerControllers characterController;


    // Start is called before the first frame update
    void Start()
    {
        characterController = FindObjectOfType<PlayerControllers>();
        totalMonsterNumber++;
        Debug.Log("Düşman ismi:" + gameObject.name + "oluştu."+ "Oyundaki toplam düşman sayısı:"+ totalMonsterNumber);
        width = GetComponent<SpriteRenderer>().bounds.extents.x;
        monster2Animator = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        monster2Animator.SetFloat("SpeedMonster2", Mathf.Abs(monter2Speed));
        //myBody.velocity = new Vector2(transform.right.x * monter2Speed, 0f);
        myBody.velocity = new Vector2(transform.right.x * monter2Speed, myBody.velocity.y);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (transform.right * width/2), Vector2.down, 2f,engel);
        if (hit.collider != null)
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }

        if (! onGround)
        {
            transform.eulerAngles += new Vector3(0, 180f, 0);
        }



        if (Vector2.Distance(transform.position, characterController.transform.position) < 10)
        {
            Attack2();

        }

    }


    void Attack2()
    {
        monster2Animator.SetTrigger("AttackMonster2");


       Collider2D[] hitPlayer =  Physics2D.OverlapCircleAll(monster2AttackPoint.position, monster2AttackRange, playerLayers);

        foreach (Collider2D player in hitPlayer)
        {
            Debug.Log("vurdu." + player.name);
        }
    }
    private void OnDrawGizmosSelected()
    {

        if (monster2AttackPoint == null)
        {
            return;

        }
        Gizmos.DrawWireSphere(monster2AttackPoint.position, monster2AttackRange);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 playerRealPosition = transform.position + (transform.right * width / 4);
        Gizmos.DrawLine(playerRealPosition, playerRealPosition + new Vector3(0, -2f, 0));
    }

    
}
