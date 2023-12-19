using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorAttribute : MonoBehaviour
{
    //Variables
    CoinManager coinManager;
    HabitabilityBarSystem habitabilitySystem;
    public float damageToHabitability=-20;
    void Start(){
        GameObject buySystem = GameObject.Find("BuySystem");

        if(buySystem!=null){
            coinManager = buySystem.GetComponent<CoinManager>();
            habitabilitySystem = buySystem.GetComponent<HabitabilityBarSystem>();
        }
        
        
    }  

    void OnMouseDown(){
        coinManager.changeCoin(coinManager.meteorCoin);
            if(habitabilitySystem.habitability>1000)
                habitabilitySystem.updateHabitability(damageToHabitability);
        gameObject.SetActive(false);
    }
}
