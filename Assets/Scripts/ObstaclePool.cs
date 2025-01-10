using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    [Serializable]
    public struct Pool
    {
        public Queue<GameObject> _objectPool;
        public GameObject _obstaclePrefab;
        public int _poolSize;
    }

    private void Awake()
    {
        InitializePool();    
    }

    [SerializeField] private Pool[] _pool;
    private void InitializePool()
    {
        for(int i = 0; i < _pool.Length; i++)
        {
            _pool[i]._objectPool = new Queue<GameObject>();
            
            for (int j = 0; j < _pool[j]._poolSize; j++)
            {
                GameObject obj = Instantiate(_pool[i]._obstaclePrefab);
                obj.SetActive(false);
                _pool[i]._objectPool.Enqueue(obj); 
                // yaratýlan nesneyi havuzun sonuna ekledik
            }
        }
    }


   public  GameObject GetPool(int ObjectType)
    {
        if(ObjectType >= _pool.Length)
        {
            return null;
        }

        GameObject obj = _pool[ObjectType]._objectPool.Dequeue();  // Havuzun baþna ekledik
        obj.SetActive(true);
        _pool[ObjectType]._objectPool.Enqueue(obj);
        // Tekrar objeyi baþa alýyorum

        return obj;

    }
}
