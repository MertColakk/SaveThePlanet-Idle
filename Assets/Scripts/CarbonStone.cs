using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarbonStone : MonoBehaviour
{
    //Variables
    float movementSpeed=7f,rotateSpeed=70f;
    HabitabilityBarSystem habitabilityBarSystem;
    Transform playerTransform;
    PlayerController playerController;
    
    void Start(){
        GameObject planet = GameObject.Find("Player");

        if(planet!=null){
            habitabilityBarSystem = planet.GetComponent<HabitabilityBarSystem>();
            playerController = planet.GetComponent<PlayerController>();

            playerTransform= playerController.transform;
        }
        
        
    }   

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,playerTransform.position,movementSpeed*Time.deltaTime); //Move to planet
        transform.Rotate(rotateSpeed*Time.deltaTime,rotateSpeed*Time.deltaTime,rotateSpeed*Time.deltaTime); //Rotate like a meteor      
    }

    //For Disable from pool object
    void OnMouseDown(){
        gameObject.SetActive(false);
    }
}
