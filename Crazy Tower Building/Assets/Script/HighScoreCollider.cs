using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HighScoreCollider : MonoBehaviour
{
     GameObject highScoreBeam;
     private BoxCollider boxCollider;
    private Vector3 highestPoint;
    private const float MULTIPLIER = 2;
    private bool canMove = true;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        highScoreBeam = gameObject.transform.GetChild(0).gameObject;
    }

    private void Update()
    {
      
        if (canMove)
        {
            MoveObjectDown();
        }
    }

    void MoveObjectDown()
    {
    
        gameObject.transform.position+=Vector3.down*Time.deltaTime*MULTIPLIER; 
    }
    
 
    private void OnCollisionEnter(Collision other)
    {
      GetFirstCollidingPoint(other);
    }

    void GetFirstCollidingPoint(Collision other)
    {
       SetBeamPosition(other);
       UIScript.Instance.ShowRestartButton();
        boxCollider.enabled = false;
        canMove = false;
    }
    
    
    void SetBeamPosition(Collision other)
    {
        highestPoint=other.contacts[0].point;
        highScoreBeam.transform.position = highestPoint; 
    }
}
