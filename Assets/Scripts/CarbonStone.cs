using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarbonStone : MonoBehaviour
{
    //Variables
    float movementSpeed=7f,rotateSpeed=70f;
    public float habitabilityAmount=30f;
    PlayerController playerController;
    HabitabilityBarSystem habitabilitySystem;
    
    void Start(){
        GameObject planet = GameObject.Find("Player");

        if(planet!=null){
            playerController = planet.GetComponent<PlayerController>();
            habitabilitySystem = planet.GetComponent<HabitabilityBarSystem>();
        }
        
        
    }   

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,playerController.transform.position,movementSpeed*Time.deltaTime); //Move to planet
        transform.Rotate(rotateSpeed*Time.deltaTime,rotateSpeed*Time.deltaTime,rotateSpeed*Time.deltaTime); //Rotate like a meteor      
    }

    //For Disable from pool object
    void OnMouseDown(){
        habitabilitySystem.updateHabitability(habitabilityAmount);
        gameObject.SetActive(false);
    }
}
