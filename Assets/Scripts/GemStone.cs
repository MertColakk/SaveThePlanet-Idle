using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemStone : MonoBehaviour
{
    //Variables
    CoinManager coinManager;
    public float damageToPlanet=-8f;
    HabitabilityBarSystem habitabilitySystem;
    public float gemStoneCoin=40f;
    
    void Start(){
        GameObject planet = GameObject.Find("Player");

        if(planet!=null){
            coinManager = planet.GetComponent<CoinManager>();
            habitabilitySystem = planet.GetComponent<HabitabilityBarSystem>();    
        }
        
        
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