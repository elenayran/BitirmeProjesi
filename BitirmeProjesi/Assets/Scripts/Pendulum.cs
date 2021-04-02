using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public Rigidbody2D body2d;
    public float leftPushRange;
    public float rigthPushRange;
    public float velocityThreshold;
    // Start is called before the first frame update
    void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
        body2d.angularVelocity = velocityThreshold;
    }

    // Update is called once per frame
    void Update()
    {
        Push();
    }

    public void Push()
    {
        if (transform.rotation.z > 0  && transform.rotation.z <rigthPushRange && (body2d.angularVelocity > 0) && body2d.angularVelocity< velocityThreshold)
        {

            body2d.angularVelocity = velocityThreshold;

        }

        else if (transform.rotation.z < 0 &&  transform.rotation.z >leftPushRange && (body2d.angularVelocity < 0) &&body2d.angularVelocity >velocityThreshold * -1)
        {

            body2d.angularVelocity = velocityThreshold * 1;
        }

    }
}
