using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PortalPlacement : MonoBehaviour
{
    ARRaycastManager ARRaycastManager;
    ARPlaneManager ARPlaneManager;
    ARPointCloudManager ARPointCloudManager;

    [SerializeField] public GameObject objectToPlace;
    [SerializeField] public GameObject placementIndicator;
    [SerializeField] AudioSource audioSource;

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
            placementIndicator.SetActive(true);
            PlaceObject();
        }
    }

    public void PlaceObject()
    {
        if (ARRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 3), raycastHits, TrackableType.PlaneWithinPolygon))
        {
            placementIndicatorPose = raycastHits[0].pose;
            placementIndicator.transform.SetPositionAndRotation(placementIndicatorPose.position, placementIndicatorPose.rotation);

            isObjectPlaced = true;
            objectToPlace.SetActive(true);

            audioSource.Play();
        }
    }

    public void ReplaceObject()
    {
        objectToPlace.SetActive(false);
        audioSource.Stop();
    }
}
