using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    //Variables
    float movementSpeed=5f,rotateSpeed=50f;
    CoinManager coinManager;
    Transform playerTransform;
    PlayerController playerController;
    CoinAmountManagger amountManager;
    
    void Start(){
        GameObject planet = GameObject.Find("Player");
        GameObject coinAmountManager = GameObject.Find("CoinAmountManager");

        if(planet!=null&&coinAmountManager!=null){
            coinManager = planet.GetComponent<CoinManager>();
            playerController = planet.GetComponent<PlayerController>();
            amountManager = coinAmountManager.GetComponent<CoinAmountManagger>();

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
        coinManager.changeCoin(amountManager.getCoinAmount("Meteor"));
        gameObject.SetActive(false);
    }

    

}
