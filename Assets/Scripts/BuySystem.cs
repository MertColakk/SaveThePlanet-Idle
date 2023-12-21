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
        [SerializeField] Image goldLevelImage;

        //Meteor Gold Gain
        [SerializeField] Button meteorButton;
        float meteorNeeded=200;
        int meteorLevel=1;
        [SerializeField] TMP_Text meteorCostText;
        [SerializeField] TMP_Text meteorLevelText;
        [SerializeField] Image meteorLevelImage;

        //CarbonStone Gold Gain
        [SerializeField] Button carbonButton;
        float carbonNeeded=275; 
        int carbonLevel=1;
        [SerializeField] TMP_Text carbonCostText;
        [SerializeField] TMP_Text carbonLevelText;
        [SerializeField] Image carbonLevelImage;

        //GemStone Gold Gain
        [SerializeField] Button gemButton;
        float gemNeeded=280; 
        int gemLevel=1;
        [SerializeField] TMP_Text gemCostText;
        [SerializeField] TMP_Text gemLevelText;
        [SerializeField] Image gemLevelImage;

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
        if(isOpen)
            Time.timeScale=0;
        else
            Time.timeScale=1;
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
            coinManager.changeCoin(-neededGold);
            goldLevel+=1;

            coinManager.coinPerSecond *= 1.8f;
            neededGold *= 1.6f;

            updateLevelImage(goldLevelImage,goldLevel);

            if(goldLevel==10)
                goldButton.interactable=false;

            updateText(costText,levelText,neededGold,goldLevel);
        }
    }

    public void upgradeMeteor(){
        if(coinManager!=null&&coinManager.coin>=meteorNeeded){
            coinManager.changeCoin(-meteorNeeded);
            meteorLevel+=1;

            coinManager.meteorCoin *= 1.8f;
            meteorNeeded *= 1.6f;

            updateLevelImage(meteorLevelImage,meteorLevel);

            if(meteorLevel==10)
                meteorButton.interactable=false;
            
            updateText(meteorCostText,meteorLevelText,meteorNeeded,meteorLevel);
        }
    }

    public void upgradeCarbon(){
        if(coinManager!=null&&coinManager.coin>=carbonNeeded){
            coinManager.changeCoin(-carbonNeeded);
            carbonLevel+=1;

            habitabilitySystem.carbonStoneHabitability *= 1.3f;
            carbonNeeded *= 1.9f;

            updateLevelImage(carbonLevelImage,carbonLevel);

            if(carbonLevel==10)
                carbonButton.interactable=false;

            updateText(carbonCostText,carbonLevelText,carbonNeeded,carbonLevel);
        }
    }

    public void upgradeGemStone(){
        if(coinManager!=null&&coinManager.coin>=gemNeeded){
            coinManager.changeCoin(-gemNeeded);
            gemLevel+=1;

            coinManager.gemStoneCoin *= 1.1f;
            gemNeeded *= 1.4f;
            
            updateLevelImage(gemLevelImage,gemLevel);

            if(gemLevel==10)
                gemButton.interactable=false;

            updateText(gemCostText,gemLevelText,gemNeeded,gemLevel);
        }
    }

    void updateLevelImage(Image levelImage,int level){
        levelImage.fillAmount = (level)*1.0f/10f;
    }


    

    
}
