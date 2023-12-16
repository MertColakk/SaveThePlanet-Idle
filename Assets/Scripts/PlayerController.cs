using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    public float planetHealth=100f,habitability=1f; //Game attribute
    float rotateSpeed=30f,recoverAmount=5f; 
    Coroutine recoverCoroutine; //For is damage taken control
    HealthBarSystem healthBarSystem; //For planets health bar
    HabitabilityBarSystem habitabilityBarSystem; //For planets habitability text


    //Start and Update fncs
    void Start()
    {
        //Getting healthbar content
        healthBarSystem = GetComponent<HealthBarSystem>();
        habitabilityBarSystem = GetComponent<HabitabilityBarSystem>();
    }

    
    void Update()
    {
        //Rotate in the axis y like planet
        transform.Rotate(0,rotateSpeed*Time.deltaTime,0);
        
        //Recover planet's health if damage taken
        if(recoverCoroutine == null)
            recoverCoroutine = StartCoroutine(recoverPlanet());
                 
    }


    //Controlling isTouched to planet
    void OnCollisionEnter(Collision other){
        if(planetHealth!=0f){
            changeHabitability(other);
            if(other.gameObject.CompareTag("Meteor"))
                TakeDamage(10f);
             
        }
    }

    //When planet take damage from an enemy
    void TakeDamage(float amount){
        planetHealth -= amount;
        healthBarSystem.UpdateHealthBar(amount,"Damage");
    }

    //When planet recovering
    void HealPlanet(float amount){
        if(planetHealth<100)
            planetHealth += amount;
        else
            planetHealth = 100;        
    }

    //Habitability changing method
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
            HealPlanet(recoverAmount);
            healthBarSystem.UpdateHealthBar(recoverAmount,"Heal");
            yield return new WaitForSeconds(2f);
        }
        recoverCoroutine = null;
    }


    
}
