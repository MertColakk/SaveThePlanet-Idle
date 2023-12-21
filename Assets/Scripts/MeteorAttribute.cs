using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeteorAttribute : MonoBehaviour
{
    //Variables
    CoinManager coinManager;
    EffectSystem effectSystem;

    void Start(){
        GameObject buySystem = GameObject.Find("BuySystem");
        GameObject system = GameObject.Find("EffectSystem");

        if(buySystem!=null&&system!=null){
            coinManager = buySystem.GetComponent<CoinManager>();
            effectSystem = system.GetComponent<EffectSystem>();
        }
            
             
    }  

    void OnMouseDown(){
        coinManager.changeCoin(coinManager.meteorCoin);
        Instantiate(effectSystem.effectsPrefab[1],transform.position,Quaternion.identity);
        Instantiate(effectSystem.effectsPrefab[7],transform.position,Quaternion.identity);
        gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Player")){
            Instantiate(effectSystem.effectsPrefab[0],transform.position,Quaternion.identity);
            Instantiate(effectSystem.effectsPrefab[6],transform.position,Quaternion.identity);
        }
                                
    }
}
