using System;
using UnityEngine;

public class PigMovement : MonoBehaviour
{
    public Joystick joystick;
    public CharacterController characterController;
    public ImageHandler imageHandler;
        
    public float speed;
        
    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float force = joystick.Direction.magnitude;
        Vector2 normal = joystick.Direction.normalized;
            
        imageHandler.ChoseDirection(normal);

        characterController.Move(normal * force * speed);
    }
}