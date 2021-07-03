using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject interactIcon;
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    private Vector2 movement;
    private Vector2 boxSize = new Vector2(0.1f,1f);

    void Update()
    {
        //INTERACTION KEY U
        if(Input.GetKeyDown(KeyCode.U)) {
             CheckInteraction();
        }

        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
        Debug.Log($"{movement.x}, {movement.y}");
    }

    void FixedUpdate() {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void OpenInteractableIcon()
    {
        interactIcon.SetActive(true);
    }

    public void CloseInteractableIcon()
    {
        interactIcon.SetActive(false);
    }

    private void CheckInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);
        if (hits.Length > 0)
        {
             foreach(RaycastHit2D rc in hits)
             {
                  if (rc.transform.GetComponent<Interactables>())
                  {
                      rc.transform.GetComponent<Interactables>().Interaction();
                      return;
                  }
             }
        }
    }
}