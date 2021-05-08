using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsTrigger : MonoBehaviour
{
    [SerializeField] GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.GetComponent<PlayerControllers>().onGround = true;

    }
}
