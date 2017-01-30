using UnityEngine;
using System.Collections;
using System;

public class HiddenObject : MonoBehaviour {
    public delegate void Found(string name);
    public event Found OnObjectFound;
    public string name;

    public void OnMouseDown()
    {
        if(OnObjectFound != null)
            OnObjectFound(name);
        Destroy(gameObject);
    }

}
