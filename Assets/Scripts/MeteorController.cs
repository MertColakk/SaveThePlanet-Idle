using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    //Variables
    float movementSpeed=5f,rotateSpeed=50f;
    public float damageToHabitability=-10;
    CoinManager coinManager;
    HabitabilityBarSystem habitabilitySystem;
    PlayerController playerController;
    public float meteorCoin=8f;
    
    void Start(){
        GameObject planet = GameObject.Find("Player");

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
        coinManager.changeCoin(meteorCoin);
        if(habitabilitySystem.habitability>1000)
            habitabilitySystem.updateHabitability(damageToHabitability);
        gameObject.SetActive(false);
    }

    

}
