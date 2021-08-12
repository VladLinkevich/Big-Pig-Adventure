using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public AnimationCurve animationCurve;
    public SpriteRenderer sprite;
    public ProjectilePool projectilePool;
    
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
        
        projectilePool.GetProjectile().Shot(bombPosition, 
            bombPosition + Vector3.right * projectileDistance);
        
        projectilePool.GetProjectile().Shot(bombPosition, 
            bombPosition + Vector3.left * projectileDistance);
        
        
        gameObject.SetActive(false);
    }
}