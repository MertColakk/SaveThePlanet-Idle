using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float rotateSpeed = 30f; 
    [SerializeField] List<GameObject> phases;
    HabitabilityBarSystem system;
 
    void Start(){
        GameObject buySystem = GameObject.Find("BuySystem");
        if(buySystem!=null)
            system = buySystem.GetComponent<HabitabilityBarSystem>();
    }
    void Update()
    {
        //Rotate in the axis y like planet
        transform.Rotate(0,rotateSpeed*Time.deltaTime,0);       

    }


    //Controlling isTouched to planet
    void OnCollisionEnter(Collision other){
        other.gameObject.SetActive(false);
                                
    }

}
