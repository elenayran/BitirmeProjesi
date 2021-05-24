using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int playerMaxHealth=100;
    public int playerCurrentHealth;
    private Rigidbody2D myBody;
    
    public Animator animator;
    public bool isAlive;

    [SerializeField] public GameObject  LosePanel;

    public PlayerControllers playerControllers;

    [SerializeField] AudioClip dieMusic;

    private Health _health;

    // Start is called before the first frame update
    void Start()
    {
        _health = GetComponent<Health>();
        playerCurrentHealth = playerMaxHealth;
        myBody = GetComponent<Rigidbody2D>();
        isAlive = true;
    }


    public void PlayerTakeDamage(int playerDamage)
    {
        
        playerCurrentHealth -= playerDamage;
        for (int i = 0; i < playerDamage / 20; i++)
        {
            _health.health -= 1;
        }
        
        animator.SetTrigger("Hurt");

        if (playerCurrentHealth <= 0)
        {
            PlayerDie();

        }

      


    }

   public void PlayerDie()
    {
        animator.SetTrigger("Die");
        isAlive = false;
       
        Debug.Log("playar öldü");
        


        GetComponent<Collider2D>().enabled = false;
        myBody.constraints = RigidbodyConstraints2D.FreezePosition;

        GameObject.Find("Sound Controller").GetComponent<AudioSource>().clip = null;
        GameObject.Find("Sound Controller").GetComponent<AudioSource>().PlayOneShot(dieMusic);



        PlayerControllers playerControllers = GetComponent<PlayerControllers>(); 
        StartCoroutine(playerControllers.Wait(false));

    }
    // Update is called once per frame
    void Update()
    {

    }

 
}
