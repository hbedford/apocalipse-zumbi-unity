using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject buttonLeave;

    private void Start()
    {
        #if UNITY_STANDALONE || UNITY_EDITOR
                buttonLeave.SetActive(true);
        #endif
    }
    public void StartGame()
    {
        SceneManager.LoadScene("game");

    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
