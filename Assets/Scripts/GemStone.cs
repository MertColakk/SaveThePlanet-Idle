using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemStone : MonoBehaviour
{
    //Variables
    CoinManager coinManager;

    public float gemStoneCoin=40f;
    
    void Start(){
        GameObject buySystem = GameObject.Find("BuySystem");

        if(buySystem!=null)
            coinManager = buySystem.GetComponent<CoinManager>();
        
        
        
    }   

    //For Disable from pool object
    void OnMouseDown(){
        coinManager.changeCoin(coinManager.gemStoneCoin);
        
        gameObject.SetActive(false);
    }
}
