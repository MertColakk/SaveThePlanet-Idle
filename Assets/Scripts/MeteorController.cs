using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    //Variables
    [SerializeField] Transform planetTransform;
    float movementSpeed=4f,rotateSpeed=50f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,planetTransform.position,movementSpeed*Time.deltaTime); //Move to planet
        transform.Rotate(rotateSpeed*Time.deltaTime,rotateSpeed*Time.deltaTime,rotateSpeed*Time.deltaTime); //Rotate like a meteor
    }

}
