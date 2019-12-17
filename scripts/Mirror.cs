using UnityEngine;

public class Mirror : MonoBehaviour
{
    public Transform mirrorCam; //Mirror cam reference, each mirror has its cam
    public LevelManager levelManager;//Ref to the camera used for the level
    private Transform playerCam;//Used to calculate the player position

    private void Start()
    {
        //Assign the used camera
        playerCam = levelManager.selectedCam;
    }

    private void Update()
    {

        //print("Cam for mirror: " + playerCam);
        CalculateRotation();
    }

    public void CalculateRotation()
    {
        //Calculate and store the dir value by getting the distance between the player's position and camera's position
        Vector3 dir = (playerCam.position - transform.position).normalized;
        Quaternion rot = Quaternion.LookRotation(dir);

        rot.eulerAngles = transform.eulerAngles - rot.eulerAngles;

        mirrorCam.localRotation = rot;
    }
}