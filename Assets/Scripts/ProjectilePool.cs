using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    public Transform parentPrefab;
    public GameObject projectilePrefab;

    public int startSize;
    
    private List<Projectile> _projectiles = new List<Projectile>();

    private void Awake()
    {
        for (int i = 0; i < startSize; ++i)
        {
            _projectiles.Add(ProjectileInstantiate());
        }
    }

    private Projectile ProjectileInstantiate()
    {
        GameObject bomb = Instantiate(projectilePrefab, parentPrefab);
        bomb.SetActive(false);

        return bomb.GetComponent<Projectile>();
    }

    public Projectile GetProjectile()
    {
        Projectile proj = null;
        
        proj = FindFreeProjectile();
        proj ??= AddedNewProjectile();
        
        return proj;
    }

    private Projectile FindFreeProjectile()
    {
        return _projectiles.FirstOrDefault(projectile => projectile.IsActive == false);
    }

    private Projectile AddedNewProjectile()
    {
        Projectile proj = ProjectileInstantiate();
        _projectiles.Add(proj);
        return proj;
    }
}