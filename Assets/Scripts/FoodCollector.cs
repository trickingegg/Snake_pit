using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollector : MonoBehaviour
{
    public FoodSpawner foodSpawn;
    public int Score { get; private set; }

    public void TryCollect()
    {
        Score++;
        Debug.Log("The scroe is " + Score);
        foodSpawn.TrySpawn();
    }
}
