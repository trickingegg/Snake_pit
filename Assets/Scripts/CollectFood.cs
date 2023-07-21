using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CollectFood : MonoBehaviour
{
    public FoodSpawn foodSpawn;

    private void OnTriggerEnter2D(Collider2D _object)
    {
        if (_object.TryGetComponent(out CollectFood2 food))
        {
            Destroy(food.gameObject);
            foodSpawn.Spawner();
        }

    }
    //first try make eating food work

    /*private void Eating()
    {
        Vector2 tailVector = transform.position;
        if (eat)
        {
            GameObject tailPiece = (GameObject)Instantiate(_tailPrefab, tailVector, Quaternion.identity);

            tail.Insert(0, tailPiece.transform);
            eat = false;
        }
        /*else if (tail.Count > 0)
        {
            tail.Last().position = tailVector;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }*/
}
