using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public float coin=0;
    [SerializeField] TMP_Text coinText;
    public float coinPerSecond=4.3f;
    public float meteorCoin=8f;
    public float gemStoneCoin=40f;
      
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
