using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSystem : MonoBehaviour
{
    //Variables
    [SerializeField] Image healthBar;
    public float maxPlanetHealth=100f,recoverAmount=5f; //Planet attribute;
    public float planetHealth=100f;
    Coroutine recoverCoroutine; //For is damage taken control

    void Start(){
         //Recover planet's health if damage taken
        if(recoverCoroutine == null)
            recoverCoroutine = StartCoroutine(recoverPlanet());
    }
    
    //When planet take damage from an enemy
    public void TakeDamage(float amount){
        planetHealth -= amount;
        UpdateHealthBar(amount,"Damage");
    }

    //When planet recovering
    public void HealPlanet(float amount){
        if(planetHealth<100)
            planetHealth += amount;
        else
            planetHealth = 100;        
    }
    public void UpdateHealthBar(float amount,string type){
        if(type=="Damage")
            healthBar.fillAmount -=  amount/maxPlanetHealth;
        else if(type=="Heal")
            healthBar.fillAmount +=  amount/maxPlanetHealth;   
    }
    public IEnumerator recoverPlanet(){
        while(planetHealth!=100){
            yield return new WaitForSeconds(4f);
            HealPlanet(recoverAmount);
            UpdateHealthBar(recoverAmount,"Heal");
            yield return new WaitForSeconds(2f);
        }
        recoverCoroutine = null;
    }
}
