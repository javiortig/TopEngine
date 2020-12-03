﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature{
//Attributes(Properties)
    

//Methods
    protected override void spawn(){
        base.spawn();
        speed = 5f;
    }

    protected override void control(){
        if (IsGrounded){
            float xI = Input.GetAxisRaw(axisName: "Horizontal");
            float zI = Input.GetAxisRaw(axisName: "Vertical");

            MovementDirection = transform.right*xI  +
                transform.forward*  zI;

            characterController.Move(
                MovementDirection*speed*Time.deltaTime);
        }
    }

    public override void EnterColision(Collider other){
        Debug.Log("He colisionao con " + other.gameObject.name);
    }

}
