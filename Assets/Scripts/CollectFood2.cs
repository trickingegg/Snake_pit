using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFood2 : MonoBehaviour
{
    //public FoodSpawn foodSpawn;
    // Start is called before the first frame update
    private static int score = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D _object)
    {
        if (_object.TryGetComponent(out SnakeMovement snake))
        {
            //eat = true;
            score++;
            Debug.Log(score);
        }

    }
}
