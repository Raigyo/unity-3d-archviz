using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    //Available cameras
    public GameObject spotCam; // Camera for spotcam reference
    public GameObject fpsController; // Reference for the GO fpsController
    public GameObject fpsCam; // Camera for fps cam reference (link to FirstPersonCharacter containing the camera)
    public GameObject cinematicCam; // Camera for cinematic cam reference
    public GameObject mainSpot; // GameObject that contain the arrows (to enbale or disable it);
    public GameObject wallColliders; // Colliders reference
    public GameObject crossHair; // Crosshair reference
    [SerializeField] private GameObject loadingScreen;//loading screen reference
    [SerializeField] private Slider slider;//progressbar
    public string nextScene;//name of next scene
    public ScriptableVars menuData;

    [System.NonSerialized]
    public Transform selectedCam;

    //Manage what's enabled according the choice of type of game
    private void gameSelection()
    {
        switch (menuData.gameSelected)
        {
            case 0:
                print("SpotCam");
                spotCam.SetActive(true);
                mainSpot.SetActive(true);
                wallColliders.SetActive(true);
                crossHair.SetActive(false);
                fpsController.SetActive(false);
                cinematicCam.SetActive(false);                
                selectedCam = spotCam.transform;
                break;
            case 1:
                print("FPSCam");
                fpsController.SetActive(true);
                wallColliders.SetActive(true);
                crossHair.SetActive(true);
                spotCam.SetActive(false);
                cinematicCam.SetActive(false);
                mainSpot.SetActive(false);                               
                selectedCam = fpsCam.transform;
                break;            
            case 2:
                print("CinematicCam");
                cinematicCam.SetActive(true);
                spotCam.SetActive(false);
                fpsCam.SetActive(false);
                mainSpot.SetActive(false);
                wallColliders.SetActive(false);
                crossHair.SetActive(false);
                selectedCam = cinematicCam.transform;
                break;
            default:
                print("Not valid");
                break;
        }
    }

    public void Awake()
    {
        gameSelection();
        loadingScreen.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            loadingScreen.SetActive(true);
            StartCoroutine(LoadAsynchronously(nextScene));
        }
    }

    IEnumerator LoadAsynchronously(string name)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);
        //freeze the game (to avoid player continue the game during preload
        Time.timeScale = 0;
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
}
