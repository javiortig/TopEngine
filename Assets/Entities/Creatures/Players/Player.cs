using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature{
//Attributes(Properties)
    //Variables used for Aiming
    Camera mainCamera;
    Plane groundPlane;

//Methods
    protected override void spawn(){
        base.spawn();

        //Instanciate variables used at Aiming
        mainCamera = FindObjectOfType<Camera>();
        groundPlane = new Plane(Vector3.up, Vector3.zero);

        speed = 5f;
    }

    protected override void control(){
        //Aiming
        float cameraRayLength;
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(groundPlane.Raycast(cameraRay, out cameraRayLength)){

            Vector3 pointToAim = cameraRay.GetPoint(cameraRayLength);
            transform.LookAt(new Vector3(pointToAim.x, 
                                        transform.position.y,
                                        pointToAim.z));
        }



        //Movement
        if (IsGrounded){
            float xI = Input.GetAxisRaw(axisName: "Horizontal");
            float zI = Input.GetAxisRaw(axisName: "Vertical");

            MovementDirection = new Vector3(xI, 0, zI);
                

            characterController.Move(
                MovementDirection*speed*Time.deltaTime);
        }
    }

    public override void EnterColision(Collider other){
        Debug.Log("He colisionao con " + other.gameObject.name);
    }

}
