using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{

    private PlayerControllers characterController;
    public Door door;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        characterController = FindObjectOfType<PlayerControllers>();
        door = FindObjectOfType<Door>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, characterController.transform.position) < 15)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider != null && hit.collider.tag == "Lever")
                {
                    Debug.Log("Levera tıkladın.");
                    door.IsOpen = true;
                    animator.SetTrigger("DoorOpen1");

                }
            }
           
        }
    }
}
