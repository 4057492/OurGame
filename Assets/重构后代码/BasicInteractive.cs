﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicInteractive : MonoBehaviour {
    bool isInterActing;
    bool acted;
    float 交互范围;
    float x;
    private void Start()
    {
        x = transform.position.x;
        交互范围 = 3f;
    }

    bool isInRange()
    {
        float dx = x - Player.current.GetXPosition();
        return (dx > -交互范围 && dx < 交互范围);
    }

    private void Update()
    {
        if (isInterActing&&isInRange())
        {
            acted = true;
            isInterActing = false;
        }
    }
    private void OnMouseEnter()
    {
        AudioSystem.current.Play("交互前");
        if (GetComponent<Mouth>() != null) MouseIcon.Change(3);
        else MouseIcon.Change(2);
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(1)&&GameSystem.isMoving)
        {
            MouseIcon.Change(1);
            x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            Player.leg.MoveTo(x);
            isInterActing = true;
        }
    }
    private void OnMouseExit()
    {
        MouseIcon.Change(1);
    }
    public bool isActed()
    {
        bool t=acted;
        if (acted)
        {
            StartCoroutine(Disact());
            Player.leg.setMoveStation(false);
        }
        return t;
    }
    IEnumerator Disact()
    {
        yield return new WaitForEndOfFrame();
        acted = false;
        yield return 0;
    }
}
