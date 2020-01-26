using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UIScript : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Text timeLeftText;
    public float timeLeft = 10;
    private bool endOfTime;
    [SerializeField] private BlocksInArea blocksInAreaScript;
    [SerializeField] private HighScoreCollider highScoreColliderScript;

    private static UIScript _instance;

    public static UIScript Instance => _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        
        if (timeLeftText == null)
        {
            Debug.LogError("timeLeftText don't added to script",timeLeftText);
        }

        if (blocksInAreaScript == null)
        {
            Debug.LogError("BlockinArea script don't added",blocksInAreaScript);
        }
        if (restartButton == null)
        {
            Debug.LogError("Restart button don't added",restartButton);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!endOfTime)
        {
            TimeSubtract();
            CheckTimeEnd();
        }
       
    }


    void TimeSubtract()
    {
        timeLeft -= Time.deltaTime;
        timeLeftText.text = "Time left: " + Mathf.Round(timeLeft);
    }

    void CheckTimeEnd()
    {
        if (timeLeft <= 0)
        {   
            blocksInAreaScript.GetAllBlocks();
            CheckHighScore();
            endOfTime = true;
        } 
    }

   public void ShowRestartButton()
   {
       restartButton.gameObject.SetActive(true);
   }

   void CheckHighScore()
    {
        highScoreColliderScript.enabled = true;
    }
}
