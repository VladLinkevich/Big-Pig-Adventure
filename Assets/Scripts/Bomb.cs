using DG.Tweening;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public AnimationCurve animationCurve;
    public SpriteRenderer sprite;
    public ProjectilePool projectilePool;

    public float[] projectileShotAngles;

    public float duration;
    public float projectileDistance;

    private void Awake()
    {
        projectilePool = FindObjectOfType<ProjectilePool>();
    }

    public void Plant()
    {
        sprite.DOColor(Color.clear, duration)
            .SetEase(animationCurve)
            .OnComplete(Shot);
    }

    private void Shot()
    {
        Vector3 bombPosition = transform.position;
        
        StartProjectile(bombPosition);

        gameObject.SetActive(false);
    }

    private void StartProjectile(Vector3 bombPosition)
    {
        foreach (float angle in projectileShotAngles)
        {
            projectilePool.GetProjectile().Shot(bombPosition,
                GetEndPoint(bombPosition, projectileDistance, angle));
        }
    }

    private Vector3 GetEndPoint(Vector3 startPoint, float distance, float angle)
    {
        return startPoint +
               new Vector3(
                   Mathf.Sin(Mathf.Deg2Rad * angle) * distance,
                   -Mathf.Cos(Mathf.Deg2Rad * angle) * distance);
    }
}