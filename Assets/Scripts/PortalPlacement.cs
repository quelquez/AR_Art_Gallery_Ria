using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PortalPlacement : MonoBehaviour
{
    [SerializeField] public GameObject objectToSpawn;
    [SerializeField] public GameObject placementIndicator;

    public ARRaycastManager ARRaycastManager;
    public ARPlaneManager ARPlaneManager;

    private GameObject spawnedObject;
    private Pose placementPose;
    private bool placementPoseIsValid = false;

    void Start()
    {
        ARRaycastManager = GetComponent<ARRaycastManager>();
        ARPlaneManager = GetComponent<ARPlaneManager>();
    }

    
    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();
    }

    public void UpdatePlacementPose()
    {

    }

    public void UpdatePlacementIndicator()
    {

    }


}
