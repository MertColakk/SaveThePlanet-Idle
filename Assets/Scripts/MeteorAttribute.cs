using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorAttribute : MonoBehaviour
{
    //Variables
    CoinManager coinManager;

    void Start(){
        GameObject buySystem = GameObject.Find("BuySystem");

        if(buySystem!=null)
            coinManager = buySystem.GetComponent<CoinManager>();
             
    }  

    void OnMouseDown(){
        coinManager.changeCoin(coinManager.meteorCoin);
        gameObject.SetActive(false);
    }
}
