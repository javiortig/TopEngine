using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : Creature{    
//Attributes(Properties)
    

//Methods
    protected override void spawn(){
        base.spawn();
        speed = 3f;
    }

    protected override void control(){
        if (IsGrounded){
            MovementDirection = new Vector3(-2, 0, 0);

            characterController.Move(
                MovementDirection*speed*Time.deltaTime);
        }
    }

    public override void EnterColision(Collider other){
        Debug.Log("He colisionao con " + other.gameObject.name);
    }
}
