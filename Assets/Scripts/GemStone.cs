using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemStone : MonoBehaviour
{
    //Variables
    float movementSpeed=7f,rotateSpeed=50f;
    CoinManager coinManager;
    public float damageToPlanet=-8f;
    HabitabilityBarSystem habitabilitySystem;
    PlayerController playerController;
    public float gemStoneCoin=40f;
    
    void Start(){
        GameObject planet = GameObject.Find("Player");
        GameObject coinAmountManager = GameObject.Find("CoinAmountManager");

        if(planet!=null){
            coinManager = planet.GetComponent<CoinManager>();
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
        coinManager.changeCoin(gemStoneCoin);
        if(habitabilitySystem.habitability>500){
            habitabilitySystem.updateHabitability(damageToPlanet);
        }
        gameObject.SetActive(false);
    }
}
