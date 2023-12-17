using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinAmountManagger : MonoBehaviour
{
    Dictionary<string,float> tagToCoin= new Dictionary<string,float>();
    float meteorCoin=8f,gemStoneCoin=60f;

    void Start(){
        tagToCoin.Add("Meteor",meteorCoin);
        tagToCoin.Add("GemStone",gemStoneCoin);
    }

    public float getCoinAmount(string tag){
        float tagCoin;

        if(tagToCoin.TryGetValue(tag,out tagCoin))
            return tagCoin;
        
        return -1f;

        
    }


}
