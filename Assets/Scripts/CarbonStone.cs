using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarbonStone : MonoBehaviour
{
    //Variables
    HabitabilityBarSystem habitabilitySystem;
    EffectSystem effectSystem;
    
    void Start(){
        GameObject buySystem = GameObject.Find("BuySystem");
        GameObject system = GameObject.Find("EffectSystem");

        if(buySystem!=null&&system!=null){
            habitabilitySystem = buySystem.GetComponent<HabitabilityBarSystem>();
            effectSystem = system.GetComponent<EffectSystem>();
        }
        
        
    }   

    //For Disable from pool object
    void OnMouseDown(){
        gameObject.SetActive(false);
        Instantiate(effectSystem.effectsPrefab[0],transform.position,Quaternion.identity);
        Instantiate(effectSystem.effectsPrefab[3],transform.position,Quaternion.identity);
    }
    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Player")){
            habitabilitySystem.updateHabitability(habitabilitySystem.carbonStoneHabitability);
            Instantiate(effectSystem.effectsPrefab[0],transform.position,Quaternion.identity);
            Instantiate(effectSystem.effectsPrefab[2],transform.position,Quaternion.identity);
        }
                                
    }
        
    
}

