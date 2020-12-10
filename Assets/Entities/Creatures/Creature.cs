using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : GameEntity{
//Attributes(Properties)
    public float AttackDamage;
    public float AbilityPower;
    protected CharacterController characterController;
    

//Methods
    protected override void spawn(){
        tags.Add(Tag.Creature);
        characterController = GetComponent<CharacterController>();
        IsGrounded = true;   
        Debug.Log("Spawnned");
    }
}
