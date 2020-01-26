using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectMove : MonoBehaviour
{
   
    private UIScript uiScript;
    private Rigidbody rigidbody;
    private const float Z_AXIS_MULTIPLIER=13.2f;
    private float mouseZCoord;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        if (rigidbody == null)
        {
            Debug.LogError("Can't find rigidbody component",rigidbody);
        }
    }

    private void Start()
    {
        mouseZCoord = gameObject.transform.position.z;
        rigidbody.isKinematic = true;
    }

    private void Update()
    {
        if (UIScript.Instance.timeLeft <= 0)
        {
            Destroy(this);
        }
    }

    Vector3 GetMouseAsWorldPosition()
  {
      Vector3 mousePoint = Input.mousePosition;
      mousePoint.z = mouseZCoord+Z_AXIS_MULTIPLIER;
      return Camera.main.ScreenToWorldPoint(mousePoint);
  }

    private void OnMouseDown()
    {
        rigidbody.isKinematic = false;
    }

    private void OnMouseDrag()
    {
        
        transform.position = GetMouseAsWorldPosition();
    }

    private void OnMouseUp()
    {
        rigidbody.isKinematic = true;
    }
}
