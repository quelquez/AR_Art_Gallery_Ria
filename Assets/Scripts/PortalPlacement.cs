using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PortalPlacement : MonoBehaviour
{
    public ARRaycastManager ARRaycastManager;
    public ARPlaneManager ARPlaneManager;
    public ARPointCloudManager ARPointCloudManager;

    [SerializeField] public GameObject objectToPlace;
    [SerializeField] public GameObject placementIndicator;

    static List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();
    private Pose placementIndicatorPose;
    private bool isObjectPlaced = false;

    void Start()
    {
        ARRaycastManager = GetComponent<ARRaycastManager>();
        ARPlaneManager = GetComponent<ARPlaneManager>();
        ARPointCloudManager = GetComponent<ARPointCloudManager>();
    }
    
    void Update()
    {
        if (isObjectPlaced == false)
        {
            PlaceObject();
        }
    }

    public void PlaceObject()
    {
        if (ARRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 3), raycastHits, TrackableType.PlaneWithinPolygon))
        {
            placementIndicatorPose = raycastHits[0].pose;
            placementIndicator.transform.SetPositionAndRotation(placementIndicatorPose.position, placementIndicatorPose.rotation);
        }

        isObjectPlaced = true;
        objectToPlace.SetActive(true);
    }
}
