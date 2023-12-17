using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Variables
    Vector3 pos1 = new Vector3(-8f, 4.25f, 0f);
    Vector3 pos2 = new Vector3(8f, 4.25f, 0f);
    Vector3 pos3 = new Vector3(8f, -4.25f, 0f);
    Vector3 pos4 = new Vector3(-8f, -4.25f, 0f);
    Vector3 chosen;
    ObjectPooler objectPooler;

    void Start(){
        objectPooler = ObjectPooler.Instance;
        objectPooler.SpawnFromPool("Meteor", chosen, Quaternion.identity);
        
    }

    

    Vector3 selectPos(int index){
        switch (index){
            case 0:
                chosen = pos1;
                break;
            case 1:
                chosen = pos2;
                break;
            case 2:
                chosen = pos3;
                break;
            case 3:
                chosen = pos4;
                break;
        }
        return chosen;
    }

    IEnumerator spawnAndWait(){
        chosen = selectPos(Random.Range(0,4));
        objectPooler.SpawnFromPool("Meteor", chosen, Quaternion.identity);

        yield return new WaitForSeconds(2f);
        
    }
}
