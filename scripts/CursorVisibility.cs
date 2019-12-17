using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

//used to switch cursor visible / lockstate properties

public class CursorVisibility : MonoBehaviour
{
    void Awake()
    {
        SceneManager.sceneLoaded += LoadScene;
    }

    // when scene loaded check if FirstPersonController exists to disable mouse cursor
    void LoadScene(Scene scene, LoadSceneMode mode)
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}