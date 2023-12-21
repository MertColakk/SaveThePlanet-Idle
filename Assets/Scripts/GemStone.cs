using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemStone : MonoBehaviour
{
    //Variables
    CoinManager coinManager;
    EffectSystem effectSystem;
    public float gemStoneCoin=40f;
    
    void Start(){
        GameObject buySystem = GameObject.Find("BuySystem");
        GameObject system = GameObject.Find("EffectSystem");

        if(buySystem!=null&&system!=null){
            coinManager = buySystem.GetComponent<CoinManager>();
            effectSystem = system.GetComponent<EffectSystem>();
        }
        
        
        
    }   

    //For Disable from pool object
    void OnMouseDown(){
        coinManager.changeCoin(coinManager.gemStoneCoin);
        Instantiate(effectSystem.effectsPrefab[1],transform.position,Quaternion.identity);
        Instantiate(effectSystem.effectsPrefab[5],transform.position,Quaternion.identity);
        gameObject.SetActive(false);
    }
    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Player")){
            Instantiate(effectSystem.effectsPrefab[0],transform.position,Quaternion.identity);
            Instantiate(effectSystem.effectsPrefab[4],transform.position,Quaternion.identity);
        }
                                
    }
}
