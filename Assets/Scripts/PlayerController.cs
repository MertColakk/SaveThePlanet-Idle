using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    HabitabilityBarSystem habitabilityBarSystem; //For planets habitability text


    //Start and Update fncs
    void Start()
    {
        //Getting healthbar and habitability text content
        habitabilityBarSystem = GetComponent<HabitabilityBarSystem>();
    }

    
    void Update()
    {
        //Rotate in the axis y like planet
        transform.Rotate(0,30*Time.deltaTime,0);          
    }


    //Controlling isTouched to planet
    void OnCollisionEnter(Collision other){
        habitabilityBarSystem.changeHabitability(other);
        if(other.gameObject.CompareTag("Meteor")){
            other.gameObject.SetActive(false);
        }                       
    }


    
}
