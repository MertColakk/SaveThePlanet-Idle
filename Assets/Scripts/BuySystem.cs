using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuySystem : MonoBehaviour
{
    //Variables      
    MeteorAttribute meteorAttribute;
    CarbonStone carbonStone;
    HabitabilityBarSystem habitabilitySystem;
    CoinManager coinManager;
    GemStone gemStone;
    [SerializeField] Image panel;
    private void Start() {
        GameObject planet = GameObject.Find("Player");
        if(planet!=null){
            meteorAttribute = planet.GetComponent<MeteorAttribute>();
            carbonStone = planet.GetComponent<CarbonStone>();
            gemStone = planet.GetComponent<GemStone>();
            habitabilitySystem = planet.GetComponent<HabitabilityBarSystem>();
            coinManager = planet.GetComponent<CoinManager>();
            panel.gameObject.SetActive(false);
        }
    }

    

    

    
}
