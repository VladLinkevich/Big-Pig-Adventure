using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ImageHandler : MonoBehaviour
{
    public Data[] imageDictionary;

    private UnitState _currentState = UnitState.None;

    private void Start()
    {
        SetCurrentState(UnitState.Default);
    }

    public ImageView GetImageView()
    {
        foreach (Data data in imageDictionary)
        {
            if (data.state == _currentState)
            {
                return data.imageView;
            }
        }

        return null;
    }

    public void SetCurrentState(UnitState state)
    {
        Debug.Log("Set Dirty");
        
        if (_currentState != UnitState.None)
            GetImageView().ChangeImageDirection(false);
        
        _currentState = state;
        GetImageView().ChangeImageDirection(true);
    }
    
    [Serializable]
    public class Data
    {
        public UnitState state;
        public ImageView imageView;
    }
}