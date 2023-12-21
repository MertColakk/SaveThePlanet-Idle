using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float rotateSpeed = 30f; 
    HabitabilityBarSystem system;
    GameObject asset,asset1,asset2;
    public GameObject changePrefab;
 
    void Start(){
        GameObject buySystem = GameObject.Find("BuySystem");
        if(buySystem!=null)
            system = buySystem.GetComponent<HabitabilityBarSystem>();

        asset = transform.GetChild(0).gameObject;
        asset1 = transform.GetChild(1).gameObject;
        asset2 = transform.GetChild(2).gameObject;

        asset1.SetActive(false);
        asset2.SetActive(false);
    }
    void Update()
    {
        //Rotate in the axis y like planet
        transform.Rotate(0,rotateSpeed*Time.deltaTime,0);
    }

    void FixedUpdate(){
        if(system.habitability>=750&&asset.activeSelf){
            asset.SetActive(false);
            asset1.SetActive(true);
            Instantiate(changePrefab,transform.position,Quaternion.identity);
        }else if(system.habitability>=1500&&asset1.activeSelf){
            asset1.SetActive(false);
            asset2.SetActive(true);
            Instantiate(changePrefab,transform.position,Quaternion.identity);
        }
    }


    //Controlling isTouched to planet
    void OnCollisionEnter(Collision other){
        other.gameObject.SetActive(false);
                                
    }

    

}
