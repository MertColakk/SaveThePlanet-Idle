using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    //Pool class
    [System.Serializable]
    public class Pool{
        //Attributes
        public string tag; 
        public GameObject prefab;
        public int size; //Size of pool
    }
    
    
    //Variables
    public Dictionary<string,Queue<GameObject>> poolDictionary;
    public List<Pool> myPool;

    #region Singleton

    public static ObjectPooler Instance;
    void Awake(){
        Instance = this;
    }

    #endregion


    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in myPool){
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i=0;i<pool.size;i++){
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag,objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag,Vector3 location,Quaternion rotation){
        
        if(!poolDictionary.ContainsKey(tag))
            return null;
        
        GameObject spawnedObject = poolDictionary[tag].Dequeue();
        spawnedObject.SetActive(true);
        spawnedObject.transform.position = location;
        spawnedObject.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(spawnedObject);
        
        return spawnedObject;
    }

    
}
