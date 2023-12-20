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
        [SerializeField] Button goldButton;
        float neededGold=125;
        int goldLevel=1;
        [SerializeField] TMP_Text costText;
        [SerializeField] TMP_Text levelText;

        //Meteor Gold Gain
        [SerializeField] Button meteorButton;
        float meteorNeeded=200;
        int meteorLevel=1;
        [SerializeField] TMP_Text meteorCostText;
        [SerializeField] TMP_Text meteorLevelText;

        //CarbonStone Gold Gain
        [SerializeField] Button carbonButton;
        float carbonNeeded=275; 
        int carbonLevel=1;
        [SerializeField] TMP_Text carbonCostText;
        [SerializeField] TMP_Text carbonLevelText;

        //GemStone Gold Gain
        [SerializeField] Button gemButton;
        float gemNeeded=280; 
        int gemLevel=1;
        [SerializeField] TMP_Text gemCostText;
        [SerializeField] TMP_Text gemLevelText;

    //Others
    HabitabilityBarSystem habitabilitySystem;
    CoinManager coinManager;
    [SerializeField] Image panel;
    
    private void Start() {
        panel.gameObject.SetActive(isOpen);
        
        habitabilitySystem = GetComponent<HabitabilityBarSystem>();
        coinManager = GetComponent<CoinManager>();

        updateAllText();
    }

    //Panel functions
    public void changePanel(){
        isOpen = !isOpen;

        panel.gameObject.SetActive(isOpen);
    }

    void updateText(TMP_Text costText,TMP_Text levelText,float cost,int level){
        costText.text = cost.ToString("F2");
        levelText.text = "Level: "+level.ToString();

        if(level==10){
            levelText.text = "MAX";
            costText.text = "";
        }
    }

    void updateAllText(){
        updateText(costText,levelText,neededGold,goldLevel);
        updateText(meteorCostText,meteorLevelText,meteorNeeded,meteorLevel);
        updateText(carbonCostText,carbonLevelText,carbonNeeded,carbonLevel);
        updateText(gemCostText,gemLevelText,gemNeeded,gemLevel);
    }

    public void upgradeCoin(){
        if(coinManager!=null&&coinManager.coin>=neededGold){
            coinManager.coin -= neededGold;
            goldLevel+=1;

            coinManager.coinPerSecond *= 1.8f;
            neededGold *= 1.6f;

            if(goldLevel==10)
                goldButton.interactable=false;

            updateText(costText,levelText,neededGold,goldLevel);
        }
    }

    public void upgradeMeteor(){
        if(coinManager!=null&&coinManager.coin>=meteorNeeded){
            coinManager.coin -= meteorNeeded;
            meteorLevel+=1;

            coinManager.meteorCoin *= 1.8f;
            meteorNeeded *= 1.6f;

            if(meteorLevel==10)
                meteorButton.interactable=false;
            
            updateText(meteorCostText,meteorLevelText,meteorNeeded,meteorLevel);
        }
    }

    public void upgradeCarbon(){
        if(coinManager!=null&&coinManager.coin>=carbonNeeded){
            coinManager.coin -= carbonNeeded;
            carbonLevel+=1;

            habitabilitySystem.carbonStoneHabitability *= 1.3f;
            carbonNeeded *= 1.9f;

            if(carbonLevel==10)
                carbonButton.interactable=false;

            updateText(carbonCostText,carbonLevelText,carbonNeeded,carbonLevel);
        }
    }

    public void upgradeGemStone(){
        if(coinManager!=null&&coinManager.coin>=gemNeeded){
            coinManager.coin -= gemNeeded;
            gemLevel+=1;

            coinManager.gemStoneCoin *= 1.1f;
            gemNeeded *= 1.4f;

            if(gemLevel==10)
                gemButton.interactable=false;

            updateText(gemCostText,gemLevelText,gemNeeded,gemLevel);
        }
    }

    //Debug fncs
    public void upradeHab(){
        habitabilitySystem.updateHabitability(100);
    }


    

    
}
