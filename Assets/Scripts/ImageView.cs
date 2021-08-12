using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageView : MonoBehaviour
{
    public GameObject upPigGameObject;
    public GameObject downPigGameObject;
    public GameObject leftPigGameObject;
    public GameObject rightPigGameObject;

    private Dictionary<Direction, GameObject> _dictionary = new Dictionary<Direction, GameObject>();
    public Direction CurrentDirection { get; private set; } = Direction.Right;

    private void Awake()
    {
        FillPigImageDictionary();
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
        CurrentDirection = direction;
        ChangeImageDirection(true);
    }

    public void ChoseDirection(Vector2 normal)
    {
        if (normal != Vector2.zero)
        {
            float angle = Mathf.Atan2(normal.x, normal.y) * Mathf.Rad2Deg;

            Direction updateDirection = CalculateDirection(angle);

            if (CurrentDirection != updateDirection)
            {
                SetDirection(updateDirection);
            }
        }
    }

    public void ChangeImageDirection(bool isActive)
    {
        if (CurrentDirection != Direction.None)
            _dictionary[CurrentDirection].gameObject.SetActive(isActive);
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
}