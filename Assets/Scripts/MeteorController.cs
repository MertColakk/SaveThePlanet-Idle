using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    //Variables
    [SerializeField] GameObject planet;
    float movementSpeed=4f,rotateSpeed=50f;
    CoinManager coinManager;
    
    void Start(){
        coinManager = planet.GetComponent<CoinManager>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,planet.transform.position,movementSpeed*Time.deltaTime); //Move to planet
        transform.Rotate(rotateSpeed*Time.deltaTime,rotateSpeed*Time.deltaTime,rotateSpeed*Time.deltaTime); //Rotate like a meteor      
    }

    //For Disable from pool object
    void OnMouseDown(){
        coinManager.changeCoin(8f);
        gameObject.SetActive(false);
    }

    

}
