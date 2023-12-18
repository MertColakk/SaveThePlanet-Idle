using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public float coin=0;
    [SerializeField] Text coinText;
    public float coinPerSecond=4.3f;
      
    void Start(){
        coin = 0;

        StartCoroutine(idleGainCoin());
    }

    public void changeCoin(float amount){
        coin += amount;
        updateCoinText(coin);
    }

    void updateCoinText(float coin){
        if(coin<1000){
            coinText.text = coin.ToString("F2");
        }else if(coin>=1000){
            coinText.text = (coin / 1000).ToString("F2") + "K";
        }
    }

    IEnumerator idleGainCoin(){
        while(true){
            coin += coinPerSecond;
            updateCoinText(coin);

            yield return new WaitForSeconds(1f);
        }
    }
}
