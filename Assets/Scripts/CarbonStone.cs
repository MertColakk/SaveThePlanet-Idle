using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarbonStone : MonoBehaviour
{
    //Variables
    HabitabilityBarSystem habitabilitySystem;
    [SerializeField] GameObject destoryPrefab,crashPrefab,destoryText,crashText;
    
    void Start(){
        GameObject buySystem = GameObject.Find("BuySystem");

        if(buySystem!=null){
            habitabilitySystem = buySystem.GetComponent<HabitabilityBarSystem>();
        }
        
        
    }   

    //For Disable from pool object
    void OnMouseDown(){
        Instantiate(crashPrefab,transform.position,Quaternion.identity);
        Instantiate(crashText,transform.position,Quaternion.identity);
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            habitabilitySystem.updateHabitability(habitabilitySystem.carbonStoneHabitability);
            Instantiate(destoryPrefab,transform.position,Quaternion.identity);
            Instantiate(destoryText,transform.position,Quaternion.identity);
        }
    }
}
