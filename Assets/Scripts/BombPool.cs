using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BombPool : MonoBehaviour
{
    public Transform parentPrefab;
    public GameObject bombPrefab;

    public int startSize;
    
    private List<GameObject> _bombs = new List<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < startSize; ++i)
        {
            _bombs.Add(BombInstantiate());
        }
    }

    private GameObject BombInstantiate()
    {
        GameObject bomb = Instantiate(bombPrefab, parentPrefab);
        bomb.SetActive(false);

        return bomb;
    }

    public GameObject GetBomb()
    {
        GameObject b = null;
        
        b = FindFreeBomb();
        b ??= AddNewBomb();

        return b;
    }

    private GameObject FindFreeBomb()
    {
        return _bombs.FirstOrDefault(bomb => bomb.activeInHierarchy == false);
    }

    private GameObject AddNewBomb()
    {
        var b = BombInstantiate();
        _bombs.Add(b);
        return b;
    }
}
