using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    public float planetHealth=100f;
    public float habitability=1f;
    float rotateSpeed=30f;


    //Start and Update fncs
    void Start()
    {
        while(true){
            if(planetHealth<100)
                StartCoroutine(recoverPlanet());
        }
    }

    
    void Update()
    {
        //Rotate in the axis y like planet
        transform.Rotate(0,rotateSpeed*Time.deltaTime,0);

                 
    }


    //Controlling isTouched to planet
    void OnCollisionEnter(Collision other){
        if(planetHealth!=0f){
            changeHabitability(other);
            if(other.gameObject.CompareTag("Meteor")){
                TakeDamage(10f);
            
            }  
                
        }
        Debug.Log(habitability);
        Debug.Log(planetHealth); 
    }

    //When planet take damage from meteor
    void TakeDamage(float amount){
        planetHealth -= amount;
    }

    //When planet heal from meteor
    void HealPlanet(float amount){
        if(planetHealth<100)
            planetHealth += amount;
        else
            planetHealth = 100;
    }

    void changeHabitability(Collision other){
        if(other.gameObject.CompareTag("Meteor"))
            if(habitability>1f)
                habitability -= 4;
                if(habitability<=1)
                    habitability = 1f;
        if(other.gameObject.CompareTag("CarbonStone"))
            habitability += 6f;
    }

    IEnumerator recoverPlanet(){
        while(planetHealth!=100){
            yield return new WaitForSeconds(4f);
            HealPlanet(5f);
            Debug.Log(planetHealth);
            yield return new WaitForSeconds(2f);
        }
    }


    
}
