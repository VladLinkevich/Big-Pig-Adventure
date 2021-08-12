using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigHandler : MonoBehaviour
{
    public GameObject upPigGameObject;
    public GameObject downPigGameObject;
    public GameObject leftPigGameObject;
    public GameObject rightPigGameObject;

    public Joystick joystick;
    public CharacterController characterController;

    public float velocity;
    
    private Dictionary<Direction, GameObject> _dictionary = new Dictionary<Direction, GameObject>();
    private Direction _currentDirection = Direction.None;
    private void Awake()
    {
        FillPigImageDictionary();
        SetDirection(Direction.Right);
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float force = joystick.Direction.magnitude;
        Vector2 normal = joystick.Direction.normalized;

        ChoseDirection(normal);

        characterController.Move(normal * force * velocity);
    }

    private void ChoseDirection(Vector2 normal)
    {
        if (normal != Vector2.zero)
        {
            float angle = Mathf.Atan2(normal.x, normal.y) * Mathf.Rad2Deg;

            Direction updateDirection = CalculateDirection(angle);

            if (_currentDirection != updateDirection)
            {
                SetDirection(updateDirection);
            }
        }
    }

    private Direction CalculateDirection(float angle)
    {
        Direction direction = Direction.None;
        
        if (Math.Abs(angle) <= 45f) { direction = Direction.Up; }
        else if (angle > 45 && angle < 135) { direction = Direction.Right; }
        else if (angle > -135 && angle < -45) { direction = Direction.Left; }
        else if (Math.Abs(angle) >= 135f) { direction = Direction.Down; }

        return direction;
    }

    private void FillPigImageDictionary()
    {
        SetupDirectionImage();
        TurnOffImage();
    }

    private void TurnOffImage()
    {
        foreach (var o in _dictionary)
        {
            o.Value.SetActive(false);
        }
    }

    private void SetupDirectionImage()
    {
        _dictionary.Add(Direction.Up, upPigGameObject);
        _dictionary.Add(Direction.Down, downPigGameObject);
        _dictionary.Add(Direction.Left, leftPigGameObject);
        _dictionary.Add(Direction.Right, rightPigGameObject);
    }

    private void SetDirection(Direction direction)
    {
        ChangeImageDirection(false);
        _currentDirection = direction;
        ChangeImageDirection(true);
    }

    private void ChangeImageDirection(bool isActive)
    {
        if (_currentDirection != Direction.None)
            _dictionary[_currentDirection].gameObject.SetActive(isActive);
    }

    public enum Direction
    {
        None, 
        Right,
        Left,
        Up,
        Down
    }

}
