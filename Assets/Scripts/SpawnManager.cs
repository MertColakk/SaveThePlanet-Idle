using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Variables
    ObjectPooler objectPooler;

    void Start(){
        objectPooler = ObjectPooler.Instance;
        StartCoroutine(spawnAndWait());
    }

    IEnumerator spawnAndWait(){
        while(true){
            int index = rateOfSpawn();
            switch(index){
                case 0:
                    objectPooler.SpawnFromPool("Meteor",new Vector3(Random.Range(-2.5f,2.5f),4f,0f), Quaternion.identity);
                    break;
                case 1:
                    objectPooler.SpawnFromPool("GemStone",new Vector3(Random.Range(-2.5f,2.5f),4f,0f), Quaternion.identity);
                    break;
                case 2:
                    objectPooler.SpawnFromPool("CarbonStone",new Vector3(Random.Range(-2.5f,2.5f),4f,0f), Quaternion.identity);
                    break;
            }

            yield return new WaitForSeconds(1.7f);
        }   
    }
    int rateOfSpawn(){
        int index,rate=Random.Range(0,100);
        if(rate>=95)
            index = 2;
        else if(rate>=85)
            index = 1;
        else
            index = 0;

        return index;
    }
}
