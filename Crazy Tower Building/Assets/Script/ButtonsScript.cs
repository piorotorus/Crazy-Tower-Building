using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    private const string SCENE_RESTART_NAME = "GameScene";
   public void RestartLevel()
    {
        SceneManager.LoadScene(SCENE_RESTART_NAME);
    }
}
