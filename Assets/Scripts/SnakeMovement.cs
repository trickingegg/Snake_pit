using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SnakeMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform tailPrefab;

    private Rigidbody2D _body;
    private Vector2 vector = Vector2.right;
    private List<Transform> _segments;
    private bool vertical = true;
    private bool horizontal = false;

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

    private void FixedUpdate()
    {
        Movement();

        for (int i = _segments.Count - 1; i > 0; i--)
            _segments[i].position = _segments[i - 1].position;
    }

    private void Movement()
    {
        _body.MovePosition(_body.position + vector * speed * Time.deltaTime);

        /*this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + vector.x, 
            Mathf.Round(this.transform.position.y) + vector.y, 
            0.0f);*/

        var deltaX = Input.GetAxis("Horizontal");
        var deltaY = Input.GetAxis("Vertical");
       
        if (deltaX > 0 && horizontal)
        {
            horizontal = false;
            vertical = true;
            vector = Vector2.right;
        }
        else if (deltaX < 0 && horizontal)
        {
            horizontal = false;
            vertical = true;
            vector = Vector2.left;
        }

        else if (deltaY > 0 && vertical)
        {
            horizontal = true;
            vertical = false;
            vector = Vector2.up;
        }
        else if (deltaY < 0 && vertical)
        {
            horizontal = true;
            vertical = false;
            vector = Vector2.down;
        }

    }

    private void Grow()
    {
        Transform tailSegment    = Instantiate(this.tailPrefab);
        tailSegment.position = _segments[_segments.Count - 1].position;

        _segments.Add(tailSegment);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out CollectFood2 food))
            Grow();
    }
}
