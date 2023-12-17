using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public float coin=0;
    [SerializeField] Text coinText;
    
    
    // Start is called before the first frame update
    void Start(){
        coin = 0;
    }

    //Function Overloading for changing method
    public void changeCoin(float amount){
        coin += amount;
        updateCoinText(coin);
    }

    void updateCoinText(float amount){
        coinText.text = amount.ToString();
    }
}
