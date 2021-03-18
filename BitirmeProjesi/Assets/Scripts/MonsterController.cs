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
    // Start is called before the first frame update
    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.extents.x;
        monster2Animator = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        monster2Animator.SetFloat("SpeedMonster2", Mathf.Abs(monter2Speed));
        myBody.velocity = new Vector2(transform.right.x * monter2Speed, 0f);
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
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 playerRealPosition = transform.position + (transform.right * width / 4);
        Gizmos.DrawLine(playerRealPosition, playerRealPosition + new Vector3(0, -2f, 0));
    }
}
