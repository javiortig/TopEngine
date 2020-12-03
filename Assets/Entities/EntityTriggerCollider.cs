using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityTriggerCollider : MonoBehaviour{
    // Start is called before the first frame update
    private Entity parentEntity;
    private Collider parentCollider;
    private Collider selfCollider;
    void Start(){
        parentEntity = GetComponentInParent<Entity>();

        //Used to Avoid collision with self colliders
        //Note: parentCollider will always be a CharacterController
        // or a Collider component
        parentCollider = GetComponentInParent<Collider>();
        selfCollider = GetComponent<Collider>();
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
