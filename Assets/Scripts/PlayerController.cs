using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float rotateSpeed = 30f; 
    void Update()
    {
        //Rotate in the axis y like planet
        transform.Rotate(0,rotateSpeed*Time.deltaTime,0);          
    }


    //Controlling isTouched to planet
    void OnCollisionEnter(Collision other){
        other.gameObject.SetActive(false);
                                
    }


    
}
