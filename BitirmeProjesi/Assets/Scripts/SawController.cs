using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{
    [SerializeField] bool onSawTrack;
    private float width;
    private Rigidbody2D myBody;
    [SerializeField] LayerMask engel;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.extents.x;
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (transform.right * width / 2), Vector2.down, 2f, engel);
        
        if (hit.collider != null)
        {
            onSawTrack = true;
        }
        else
        {
            onSawTrack = false;


        }


        if (!onSawTrack)
        {
            transform.eulerAngles += new Vector3(0, 180f, 0);
        }


        myBody.velocity = new Vector2(transform.right.x * speed, myBody.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 SawRealPosition = transform.position + (transform.right * width / 2);
        Gizmos.DrawLine(SawRealPosition, SawRealPosition + new Vector3(0, -2f, 0));
    }
}
