using System;
using DG.Tweening;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float duration;
    
    public bool IsActive => gameObject.activeInHierarchy;
    
    private Tween _tween;
    
    public void Shot(Vector3 startPosition, Vector3 endPosition)
    {
        gameObject.SetActive(true);
        
        transform.position = startPosition;
        _tween = transform.DOMove(endPosition, duration)
            .OnComplete(() => gameObject.SetActive(false));
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile") == true) return;
        
        _tween.Kill();
        
        Debug.Log($"{other.gameObject.tag}");
        other.gameObject.GetComponent<ImageHandler>()?.SetCurrentState(UnitState.Dirty);
        gameObject.SetActive(false);
    }
}
