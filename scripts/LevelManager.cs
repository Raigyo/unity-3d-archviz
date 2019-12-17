using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    //Scriptable Object ScriptableVars.cs
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
