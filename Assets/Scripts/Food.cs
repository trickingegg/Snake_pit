using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D _object)
    {
        FoodCollector foodCollector = _object.GetComponent<FoodCollector>();

        if (foodCollector != null)
        {
            foodCollector.TryCollect();
            Destroy(this.gameObject);
        }
    }
}
