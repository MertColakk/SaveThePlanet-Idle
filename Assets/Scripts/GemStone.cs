using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemStone : MonoBehaviour
{
    //Variables
    float movementSpeed=7f,rotateSpeed=50f;
    CoinManager coinManager;
    Transform playerTransform;
    PlayerController playerController;
    public float gemStoneCoin=40f;
    
    void Start(){
        GameObject planet = GameObject.Find("Player");
        GameObject coinAmountManager = GameObject.Find("CoinAmountManager");

        if(planet!=null){
            coinManager = planet.GetComponent<CoinManager>();
            playerController = planet.GetComponent<PlayerController>();

            playerTransform= playerController.transform;
        }
        
        
    }   

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,playerTransform.position,movementSpeed*Time.deltaTime); //Move to planet
        transform.Rotate(rotateSpeed*Time.deltaTime,rotateSpeed*Time.deltaTime,rotateSpeed*Time.deltaTime); //Rotate like a meteor      
    }

    //For Disable from pool object
    void OnMouseDown(){
        coinManager.changeCoin(gemStoneCoin);
        gameObject.SetActive(false);
    }
}
