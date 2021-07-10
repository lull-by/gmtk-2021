using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBall : Interactables
{
    public GameObject interactIcon;
    private bool isActive;
    public GameObject Player;
    private SpriteRenderer[] sprites;

    private float speed = 5f;
    private Vector2 target;
    private Vector2 position;


    public override void Interaction()
    {
        if(isActive)
            setState(false, Player);
        else
            setState(true, Player);
        isActive = !isActive;
    }

    private void Start()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
        isActive = true;
    }

    void Update()
    {
        if(!isActive)
        {
            target = Player.transform.position;
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, step);
        }

    }

    private void setState(bool state, GameObject player)
    {
        for(int i = 0; i < sprites.Length; i++) {
            sprites[i].enabled = state;
        }
    }


}