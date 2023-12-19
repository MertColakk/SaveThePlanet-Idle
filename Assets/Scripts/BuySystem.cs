using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class BuySystem : MonoBehaviour
{
    //Variables      
    bool isOpen=false;

    //Gold variables
    float neededGold=120;
    int level=0;
    [SerializeField] Text costText;
    [SerializeField] Text levelText;

    //Others
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
            panel.gameObject.SetActive(isOpen);
            updateText(costText,neededGold);
        }
    }

    //Panel functions
    public void changePanel(){
        isOpen = !isOpen;

        panel.gameObject.SetActive(isOpen);
    }

    void updateText(Text text,float amount){
        text.text = amount.ToString();
    }
    void updateText(Text text,int amount){
        text.text = "Level: "+amount.ToString();
    }

    public void upgradeCoin(){
        if(coinManager.coin>=neededGold){
            coinManager.coin-= neededGold;
            coinManager.coinPerSecond *= 1.6f;
            neededGold *= 1.8f;
            level++;
            updateText(levelText,level);
        }
        updateText(costText,neededGold);
    }

    

    
}
