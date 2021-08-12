using UnityEngine;
using Random = UnityEngine.Random;

public class OpponentMovement : MonoBehaviour
{
    public CharacterController characterController;
    public ImageHandler imageHandler;
    public float[] moveAngles;

    public float durationBetweenChangeDirection = 0;
    public float speed = 0;

    private float _startChangeDirectionTimer;
    private float _currentMoveAngle;

    private void Update()
    {
        UpdateTimer();
        UpdateDirection();
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        characterController.Move(AngleToVector2(_currentMoveAngle) * speed);
    }

    private void UpdateDirection()
    {
        if (_startChangeDirectionTimer < durationBetweenChangeDirection) return;

        _startChangeDirectionTimer = 0;
        _currentMoveAngle = moveAngles[Random.Range(0, moveAngles.Length)];
        imageHandler.GetImageView()?.ChoseDirection(AngleToVector2(_currentMoveAngle));
    }

    private Vector2 AngleToVector2(float angle)
    {
        return new Vector2(
            Mathf.Sin(Mathf.Deg2Rad * angle),
            -Mathf.Cos(Mathf.Deg2Rad * angle));
    }

    private void UpdateTimer() => _startChangeDirectionTimer += Time.deltaTime;
}