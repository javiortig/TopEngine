using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature{
//Attributes(Properties)
    public int AttackDamage;
    public int AbilityPower;


    public CharacterController characterController;

//Methods
    protected override void spawn(){
        IsGrounded = true;   
        Debug.Log("Spawnned");

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
