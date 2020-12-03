using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pruebecillas : MonoBehaviour
{   
    public CharacterController characterController;

    // Update is called once per frame
    void FixedUpdate(){
        characterController.Move(
            new Vector3(-2*Time.deltaTime, 0f, 0f));
    }

}
