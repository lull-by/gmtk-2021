using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public abstract class Interactables : MonoBehaviour
{
    // Check for if interactable
    private void Check()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    // God I love pornography
    public astract void Interaction();

    // When you get to an interactable
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // tag is if player is at an interactable thing (door or some shit)
        if (collision.CompareTag("Player")) {
            collision.GetComponent<CharacterControl>().OpenInteractableIcon();
        }
    }

    // When you leave interactable
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            collision.GetComponent<CharacterControl>().CloseInteractableIcon();
	}
    }
}
