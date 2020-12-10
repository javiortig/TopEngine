using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityTriggerCollider : MonoBehaviour{
    // Start is called before the first frame update
    private GameEntity parentEntity;
    private Collider parentCollider;
    private Collider selfCollider;
    void Start(){
        parentEntity = GetComponentInParent<GameEntity>();
        //Used to Avoid collision with self colliders
        //Note: parentCollider will always be a CharacterController
        // or a Collider component. It will be used for Physical movement
        //The Collider of this object will be used for triggering

        Physics.IgnoreCollision(
            selfCollider,
            parentCollider);
    }

    private void addColliders(){
        //TODO: coger el colisionador del padre probando cada tipo,
        //ponerselo a este, copiar sus valores y aumentar radio/tamaño...
        //un 10% por ejemplo. activar el isTrigger tambien
        SphereCollider temp = GetComponentInParent<SphereCollider>();
        if (temp != null){
            
        }


    }

    private void addSelfCollider2<T>() where T : Component
    {
        this.gameObject.AddComponent<T>();
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
