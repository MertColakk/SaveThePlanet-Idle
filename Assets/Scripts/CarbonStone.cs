using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarbonStone : MonoBehaviour
{
    //Variables
    public float habitabilityAmount=30f;
    HabitabilityBarSystem habitabilitySystem;
    
    void Start(){
        GameObject buySystem = GameObject.Find("BuySystem");

        if(buySystem!=null){
            habitabilitySystem = buySystem.GetComponent<HabitabilityBarSystem>();
        }
        
        
    }   

    //For Disable from pool object
    void OnMouseDown(){
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            habitabilitySystem.updateHabitability(habitabilityAmount);
        }
    }
}
