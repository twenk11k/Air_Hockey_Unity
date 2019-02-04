﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool wasJustClicked = true;
    bool canMove;
    Rigidbody2D rb;
    public Transform boundaryHolder;
    Boundary playerBoundary;
    Collider2D playerCollider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        playerBoundary = new Boundary(boundaryHolder.GetChild(0).position.y
            ,boundaryHolder.GetChild(1).position.y
            ,boundaryHolder.GetChild(2).position.x
            ,boundaryHolder.GetChild(3).position.x
            );

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (wasJustClicked)
            {
                wasJustClicked = false;
                if (playerCollider.OverlapPoint(mousePos))
                {
                    canMove = true;
                } else
                {
                    canMove = false;
                }
              
            }

            if (canMove)
            {
                Vector2 clampedMousePos = new Vector2(Mathf.Clamp(mousePos.x,playerBoundary.Left,
                    playerBoundary.Right),Mathf.Clamp(mousePos.y,playerBoundary.Down,playerBoundary.Up));

                rb.MovePosition(clampedMousePos);
            }
        }
        else
        {
            wasJustClicked = true;
        }
    }
}
