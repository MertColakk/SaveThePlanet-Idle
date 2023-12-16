using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        //Rotate in the axis y like planet
        transform.Rotate(0,30*Time.deltaTime,0);
    }


    
}
