using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Damage Types:
    -PhysicalDamage applies attackDamage vs armor
    -MagicalDamage applies abilityPower vs MR
    -Hibrid applies 50% of each and split in half to armor and mr
    -TrueDamage ignores resistances and applies a damageType 
     depending on each weapon/proyectile
*/
public enum DamageType{
    PhysicalDamage, MagicalDamage, HibridDamage, TrueDamage
}

public class Proyectile : GameEntity{
//Attributes(Properties)
    public float damage;
    DamageType type;


//Methods
    protected override void spawn(){
        
    }

    protected override void control(){
        
    }

    public override void EnterColision(Collider other){
        Debug.Log("He dañado a " + other.gameObject.name);
        GameEntity otherEntity = other.GetComponent<GameEntity>();
        
        otherEntity.receiveDamage(type, damage);
    }
}
