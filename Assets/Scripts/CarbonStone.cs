using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarbonStone : MonoBehaviour
{
    //Variables
    public float habitabilityAmount=30f;
    HabitabilityBarSystem habitabilitySystem;
    
    void Start(){
        GameObject planet = GameObject.Find("Player");

        if(planet!=null){
            habitabilitySystem = planet.GetComponent<HabitabilityBarSystem>();
        }
        
        
    }   

    //For Disable from pool object
    void OnMouseDown(){
        habitabilitySystem.updateHabitability(habitabilityAmount);
        gameObject.SetActive(false);
    }
}
