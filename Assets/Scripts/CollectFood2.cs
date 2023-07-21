using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFood2 : MonoBehaviour
{
    private static int score = 0;

    private void OnTriggerEnter2D(Collider2D _object)
    {
        if (_object.TryGetComponent(out SnakeMovement snake))
        {
            //add score ui update later;
            score++;
            Debug.Log(score);
        }

    }
}
