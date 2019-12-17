using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;//loading screen reference
    [SerializeField] private Slider slider;//progressbar
    public GameObject overlayMain;//Intro: main GUI overlay
    public string nextScene;//name of next scene
    public ScriptableVars scriptableVars;//scriptable object ref
    // Start is called before the first frame update
    void Start()
    {
        loadingScreen.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Detect which mode has been selected in menu
    public void GameMode(int modeSelected)
    {
        scriptableVars.gameSelected = modeSelected; ;
    }

    //to hide GUI when we leave intro
    public void hideGui()
    {
        //overlayIntroLoading.SetActive(true);
        overlayMain.SetActive(false);
    }

    IEnumerator LoadAsynchronously(string name)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);
        //freeze the game (to avoid player continue the game during preload
        loadingScreen.SetActive(true);
        overlayMain.SetActive(false);
        //set loading screen active
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            //progressText.text = progress * 100f + "%";

            yield return null;
        }
        //preload bar then screen fade out
    }

    //Scene changer
    public void LoadScene()
    {

       StartCoroutine(LoadAsynchronously(nextScene));

    }

    //Intro: exit button
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                        Application.Quit ();
#endif
    }


}
