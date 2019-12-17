using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitBehaviour : MonoBehaviour
{
    public LevelManager levelManager;//Ref to the camera used for the level
    Camera cam; //To manage which camera is used
    public List<GameObject> collidersToChangeRoom; //List of colliders
    public LayerMask spotCamLayer; //layer on SpotCam view to change room
    public Color tempColorReset; //To manage alpha on arrows
    private GameObject[] hotspots;

    // Start is called before the first frame update
    void Start()
    {
        cam = levelManager.selectedCam.GetComponent<Camera>();
        print("Bevaviour camera: " + cam);
    }

    private void OnEnable()
    {
        hotspots = GameObject.FindGameObjectsWithTag("Hotspot");
    }

    //Reset arrows colors
    public void resetArrows()
    {
        for (int i = 0; i < hotspots.Length; i++)
        {
            tempColorReset = hotspots[i].GetComponentInChildren<Image>().color;
            tempColorReset.a = 0.3f;
            hotspots[i].GetComponentInChildren<Image>().color = tempColorReset;
        }
    }

    // Update is called once per frame
    void Update()
    {
 
        //Raycast management
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0)); //center pointer with camera
        RaycastHit hit;

        //Check if camera hit Interactive objects / hotspots on layer 9
        if (Physics.Raycast(ray, out hit, 10, spotCamLayer))
        {
            for (int i = 0; i < collidersToChangeRoom.Count; i++)
            {
                if (hit.transform.gameObject == collidersToChangeRoom[i])
                {
                    //Detect Arrow spot selected by raycast
                    Transform parentObject = collidersToChangeRoom[i].transform.parent;
                    GameObject arrowObject = parentObject.transform.Find("Arrow Spot").gameObject;
                    GameObject arrowObjectImage = arrowObject.transform.Find("Image").gameObject;
                    var tempColor = arrowObjectImage.GetComponent<Image>().color;
                    tempColor.a = 1f;
                    arrowObjectImage.GetComponent<Image>().color = tempColor;
                }
            }

            //Actions avalaible with mouse on Interactive Layer => SpotCamChangeRoom to change room in Freecam
            if (Input.GetMouseButtonDown(0))
            {
                //Check if component script exists then call the function in FreeCamChangeRoom.cs            
                if (hit.transform.gameObject.GetComponent("SpotCamChangeRoom"))
                {
                    hit.transform.gameObject.GetComponent<SpotCamChangeRoom>().goToRoom();
                }
            }
        }

        //No Interactive or Floor objects
        //Default cursors 
        else
        {
            resetArrows();
        }
    }
}
