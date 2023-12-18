using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorAttribute : MonoBehaviour
{
    //Variables
    CoinManager coinManager;
    HabitabilityBarSystem habitabilitySystem;
    public float meteorCoin=8f,damageToHabitability=-20;
    void Start(){
        GameObject planet = GameObject.Find("Player");

        if(planet!=null){
            coinManager = planet.GetComponent<CoinManager>();
            habitabilitySystem = planet.GetComponent<HabitabilityBarSystem>();
        }
        
        
    }  

    void OnMouseDown(){
        coinManager.changeCoin(meteorCoin);
            if(habitabilitySystem.habitability>1000)
                habitabilitySystem.updateHabitability(damageToHabitability);
        gameObject.SetActive(false);
    }
}
