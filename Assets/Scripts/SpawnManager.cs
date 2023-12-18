using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Variables
    Vector3 pos1 = new Vector3(-2.5f, 4f, 0f);
    Vector3 pos2 = new Vector3(2.5f, 4f, 0f);
    Vector3 pos3 = new Vector3(2.5f, -4f, 0f);
    Vector3 pos4 = new Vector3(-2.5f, -4f, 0f);
    ObjectPooler objectPooler;

    void Start(){
        objectPooler = ObjectPooler.Instance;
        StartCoroutine(spawnAndWait());
    }

    IEnumerator spawnAndWait(){
        while(true){
            int index = rateOfSpawn();
            if(index==0)
                objectPooler.SpawnFromPool("Meteor", selectPos(Random.Range(0,4)), Quaternion.identity);
            else if(index==1)
                objectPooler.SpawnFromPool("GemStone", selectPos(Random.Range(0,4)), Quaternion.identity);
            else
                objectPooler.SpawnFromPool("CarbonStone", selectPos(Random.Range(0,4)), Quaternion.identity);

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
    Vector3 selectPos(int location){
        switch (location){
            case 0:
                return pos1;    
            case 1:
                return pos2;
                
            case 2:
                return pos3;
                
            case 3:
                return pos4;

        }
        return Vector3.zero;
    }
}
