using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SnakeMovement : MonoBehaviour
{
    public enum Direction { None = 0, Up = 1, Down = 2, Right = 3, Left = 4 };

    public float speed = 1.0f;
    public Transform tailPrefab;

    private Rigidbody2D _body;
    public Direction direction;
    private Vector2 vector = Vector2.right;
    private List<Transform> _segments;

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _segments = new List<Transform>();
        _segments.Add(this.transform);
        direction = Direction.None;
    }

    private void Update()
    {
        UpdateMovement();

        for (int i = _segments.Count - 1; i > 0; i--)
            _segments[i].position = _segments[i - 1].position;
    }

    private void UpdateMovement()
    {
        _body.MovePosition(_body.position + vector * speed * Time.deltaTime);
        
        var deltaX = Input.GetAxis("Horizontal");
        var deltaY = Input.GetAxis("Vertical");

        switch (direction)
        {
            case Direction.Right:
                vector = Vector2.right;
                break;
            case Direction.Left:
                vector = Vector2.left;
                break;
            case Direction.Up:
                vector = Vector2.up;
                break;
            case Direction.Down:
                vector = Vector2.down;
                break;
        }

        if (deltaX > 0)
            direction = Direction.Right;
        else if (deltaX < 0)
            direction = Direction.Left;
        else if (deltaY > 0)
            direction = Direction.Up;
        else if (deltaY < 0)
            direction = Direction.Down;
    }

    private void Grow()
    {
        Transform tailSegment    = Instantiate(this.tailPrefab);
        tailSegment.position = _segments[_segments.Count - 1].position;

        _segments.Add(tailSegment);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Food food))
            Grow();
    }
}
