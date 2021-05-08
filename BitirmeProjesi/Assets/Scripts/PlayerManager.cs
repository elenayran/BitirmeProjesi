using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int playerMaxHealth=100;
    int playerCurrentHealth;
    private Rigidbody2D myBody;
    
    public Animator animator;
    public bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        myBody = GetComponent<Rigidbody2D>();
        isAlive = true;
    }


    public void PlayerTakeDamage(int playerDamage)
    {
        playerCurrentHealth -= playerDamage;

        animator.SetTrigger("Hurt");

        if (playerCurrentHealth <= 0)
        {
            PlayerDie();

        }
    }

    void PlayerDie()
    {
        isAlive = false;
        Debug.Log("playar öldü");
        animator.SetTrigger("Die");

        GetComponent<Collider2D>().enabled = false;
        myBody.constraints = RigidbodyConstraints2D.FreezePosition;

    }
    // Update is called once per frame
    void Update()
    {

    }

 
}
