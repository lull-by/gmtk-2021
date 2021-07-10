using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openable : Interactables
{
    public GameObject interactIcon;
    public Sprite opened;
    public Sprite closed;

    private SpriteRenderer rend;
    private bool isOpen;

    public override void Interaction()
    {
        if(isOpen)
            rend.sprite = closed;
        else
            rend.sprite = opened;
        isOpen = !isOpen;
    }

    private void Start() 
    {
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = closed;
    }

}
