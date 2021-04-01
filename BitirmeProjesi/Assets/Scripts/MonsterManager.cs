using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public Animator Animator;
    private Rigidbody2D myBody;


    public int maxHealth=100;
    int currentHealth;
    public bool isAlive;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        myBody = GetComponent<Rigidbody2D>();
        isAlive = true;
    }


  

    public void TakeDamage(int damage)
    {
        Animator.SetTrigger("HurtMonster2");
        Animator.SetTrigger("HurtMonster");

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();

        }
    }
    void Die()
    {
        isAlive = false;
        Debug.Log("MONSTER ÖLDÜ");
        Animator.SetBool("DieMonster", true);
        Animator.SetBool("DieMonster2", true);

        
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        myBody.constraints = RigidbodyConstraints2D.FreezePosition;
        

    }


    
}
