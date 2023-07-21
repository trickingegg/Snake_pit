using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class FoodSpawn : MonoBehaviour
{
    private int numberOfObjects = 1;


    [SerializeField] private GameObject _foodPrefab;
    
    private void Start()
    {
        Spawner();
    }

    public void Spawner()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            var posX = Random.Range(.0f, 1.0f);
            var posY = Random.Range(.0f, 1.0f);
            Vector2 vector = Camera.main.ViewportToWorldPoint(new Vector2(posX, posY));
            Instantiate (_foodPrefab, vector, Quaternion.identity);
        }
    }

}
