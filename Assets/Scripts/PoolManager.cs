using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] GameObject _projectileContainer;
    [SerializeField] List<GameObject> _projectilePool;

    private void Start()
    {
        GenerateProjectiles(10); //get 10 bombs in pool by default
    }

    private List<GameObject> GenerateProjectiles(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            CreateProjectile();
        }

        return _projectilePool;
    }

    public GameObject RequestProjectile()
    {
        foreach (var projectile in _projectilePool)
        {
            if (!projectile.activeInHierarchy)
            {
                projectile.SetActive(true);
                return projectile;
            }
        }

        GameObject newProjectile = CreateProjectile(true);
        return newProjectile;
    }

    private GameObject CreateProjectile(bool isActive = false)
    {
        GameObject projectile = Instantiate(_projectilePrefab);
        projectile.transform.parent = _projectileContainer.transform;
        projectile.SetActive(isActive);
        _projectilePool.Add(projectile);
        return projectile;
    }
}
