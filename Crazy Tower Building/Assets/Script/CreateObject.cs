using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CreateObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;

    private void Start()
    {
        
    }

    private void OnMouseDown()
    {
        GameObject objecClone=Instantiate(objectToSpawn,transform.position,transform.rotation) as GameObject;

     
    }

    private void OnMouseUp()
    {
        Destroy(this);
    }
}
