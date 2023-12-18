using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    //Variables
    float movementSpeed=3f,rotateSpeed=50f;
    PlayerController playerController;

    void Start(){
        
        GameObject planet = GameObject.Find("Player");
        if(planet!=null)
            playerController = planet.GetComponent<PlayerController>();

        if(gameObject.CompareTag("CarbonStone"))
            movementSpeed = 5f;
        else if(gameObject.CompareTag("GemStone"))
            movementSpeed = 4f;
    }
     

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,playerController.transform.position,movementSpeed*Time.deltaTime); //Move to planet
        transform.Rotate(rotateSpeed*Time.deltaTime,rotateSpeed*Time.deltaTime,rotateSpeed*Time.deltaTime); //Rotate like a meteor      
    }
    

    

}
