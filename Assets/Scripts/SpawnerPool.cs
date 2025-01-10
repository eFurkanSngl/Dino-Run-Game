using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SpawnerPool : MonoBehaviour
{
    [SerializeField] private ObstaclePool _obstaclePool;
    private WaitForSeconds _wait = new WaitForSeconds(3);
    private void Start()
    {
       SpawnPool();
    }
    IEnumerator SpawnPool()
    {
        while (true)
        {
            int counter = 0;
            GameObject obj = _obstaclePool.GetPool(counter++ %2);
            obj.transform.position = new Vector2(22.50f, -5f);
            yield return _wait;
        }
    }
    

}    
