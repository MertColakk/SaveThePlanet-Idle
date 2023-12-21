using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeteorAttribute : MonoBehaviour
{
    //Variables
    CoinManager coinManager;
    [SerializeField] GameObject destoryPrefab,crashPrefab,destoryText,crashText;

    void Start(){
        GameObject buySystem = GameObject.Find("BuySystem");

        if(buySystem!=null)
            coinManager = buySystem.GetComponent<CoinManager>();
             
    }  

    void OnMouseDown(){
        coinManager.changeCoin(coinManager.meteorCoin);
        Instantiate(destoryPrefab,transform.position,Quaternion.identity);
        Instantiate(destoryText,transform.position,Quaternion.identity);
        gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Player")){
            Instantiate(crashText,transform.position,Quaternion.identity);
            Instantiate(crashPrefab,transform.position,Quaternion.identity);
        }
            
    }
}
