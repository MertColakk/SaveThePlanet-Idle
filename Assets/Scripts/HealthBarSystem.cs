using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSystem : MonoBehaviour
{
    //Variables
    [SerializeField] Image healthBar;
    float maxPlanetHealth=100f;
    
    
    public void UpdateHealthBar(float amount,string type){
        if(type=="Damage")
            healthBar.fillAmount -=  amount/maxPlanetHealth;
        else if(type=="Heal")
            healthBar.fillAmount +=  amount/maxPlanetHealth;   
    }
}
