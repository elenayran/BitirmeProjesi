using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterFollow : MonoBehaviour
{
    public float monterSpeed;
    public float stoppingDistance;
    private Animator monsterAnimator;
    private Transform target;
   
   
    
    // Start is called before the first frame update
    void Start()
    {
        monsterAnimator = GetComponent<Animator>();
       
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        monsterAnimator.SetFloat("SpeedMonster", Mathf.Abs(monterSpeed));


        if (Vector2.Distance(transform.position, target.position) > 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, monterSpeed * Time.deltaTime);
            
           
        }
        
    
       

        
       
    }
}
