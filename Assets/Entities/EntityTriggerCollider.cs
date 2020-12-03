using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityTriggerCollider : MonoBehaviour{
    // Start is called before the first frame update
    private Entity parentEntity;
    private Collider parentCollider;
    private Collider selfCollider;
    void Start(){
        parentCollider = GetComponentInParent<CharacterController>();
        selfCollider = GetComponent<Collider>();

        parentEntity = GetComponentInParent<Entity>();
        Physics.IgnoreCollision(
            selfCollider,
            parentCollider);
    }

    //Call the Entity respective function to do the behaviour
    void OnTriggerEnter(Collider other){
        parentEntity.EnterColision(other);
    }

    void OnTriggerStay(Collider other){
        parentEntity.StayColision(other);
    }

    void OnTriggerExit(Collider other){
        parentEntity.ExitColision(other);
    }
}
