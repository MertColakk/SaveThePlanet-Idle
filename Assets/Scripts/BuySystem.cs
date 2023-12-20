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
        int goldLevel=1;
        [SerializeField] TMP_Text costText;
        [SerializeField] TMP_Text levelText;

        //Meteor Gold Gain
        float meteorNeeded=200;
        int meteorLevel=1;
        [SerializeField] TMP_Text meteorCostText;
        [SerializeField] TMP_Text meteorLevelText;

        //Meteor Gold Gain
        float carbonNeeded=50;
        int carbonLevel=1;
        [SerializeField] TMP_Text carbonCostText;
        [SerializeField] TMP_Text carbonLevelText;

    //Others
    MeteorAttribute meteorAttribute;
    CarbonStone carbonStone;
    HabitabilityBarSystem habitabilitySystem;
    CoinManager coinManager;
    GemStone gemStone;
    [SerializeField] Image panel;
    private void Start() {
        GameObject carbonStoneObj = GameObject.FindWithTag("CarbonStone");

        isOpen=false;
        panel.gameObject.SetActive(isOpen);
        
        meteorAttribute = GetComponent<MeteorAttribute>();
        carbonStone = carbonStoneObj.GetComponent<CarbonStone>();
        gemStone = GetComponent<GemStone>();
        habitabilitySystem = GetComponent<HabitabilityBarSystem>();
        coinManager = GetComponent<CoinManager>();

        updateText(costText,neededGold);
        updateText(levelText,goldLevel);
        updateText(meteorCostText,meteorNeeded);
        updateText(meteorLevelText,meteorLevel);
        updateText(carbonCostText,carbonNeeded);
        updateText(carbonLevelText,carbonLevel);
    }

    //Panel functions
    public void changePanel(){
        isOpen = !isOpen;

        panel.gameObject.SetActive(isOpen);
    }

    //Function overloading for text
    void updateText(TMP_Text text,float amount){
        text.text = amount.ToString();
    }
    void updateText(TMP_Text text,int amount){
        text.text = "Level: "+amount.ToString();
    }

    public void upgradeCoin(){
        if(coinManager!=null&&coinManager.coin>=neededGold){
            coinManager.coin -= neededGold;
            goldLevel+=1;

            coinManager.coinPerSecond *= 1.8f;
            neededGold *= 1.6f;

            updateText(costText,neededGold);
            updateText(levelText,goldLevel);
        }
    }

    public void upgradeMeteor(){
        if(coinManager!=null&&coinManager.coin>=meteorNeeded){
            coinManager.coin -= meteorNeeded;
            meteorLevel+=1;

            coinManager.meteorCoin *= 1.8f;
            meteorNeeded *= 1.6f;

            updateText(meteorCostText,meteorNeeded);
            updateText(meteorLevelText,meteorLevel);
        }
    }

    public void upgradeCarbon(){
        if(carbonStone!=null&&coinManager.coin>=carbonNeeded){
            coinManager.coin -= carbonNeeded;
            carbonLevel+=1;

            carbonStone.habitabilityAmount *= 3f;
            carbonNeeded *= 2.1f;

            updateText(carbonCostText,carbonNeeded);
            updateText(carbonLevelText,carbonLevel);
        }
    }


    

    
}
