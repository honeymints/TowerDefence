using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingObject : MonoBehaviour
{
    private List<GameObject> _poolPrefab = new List<GameObject>();
    
    public GameObject Spawn(Transform pos, Quaternion rotation, GameObject prefab)
    { 
        return SpawnPrefabObject(_poolPrefab, prefab, rotation, pos.position);
    }

    private GameObject SpawnPrefabObject(List<GameObject> pool, GameObject prefab, Quaternion rotationPos, Vector3 position)
    {
        for (int i = 0; i < pool.Count; i++)
        {
           
            if (pool[i].activeInHierarchy == false)
            {
                Debug.Log(_poolPrefab.Count);
                pool[i].transform.position = position;
                pool[i].transform.rotation = rotationPos;
                pool[i].SetActive(true);
                return pool[i];
            }
        }

        GameObject ob = Instantiate(prefab, position, rotationPos);
        _poolPrefab.Add(ob);
        return ob;
    }
}
