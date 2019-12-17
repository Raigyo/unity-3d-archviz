using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotCamChangeRoom : MonoBehaviour
{
    public Transform ToRoom;
    public GameObject defaultCameraType;

    public void goToRoom()
    {
        print("ToRoom: " + ToRoom);
        SpotCamMouseMovements.instance.target = ToRoom;
    }
}