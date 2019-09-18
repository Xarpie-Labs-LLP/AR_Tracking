﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class Main_Scene_btn : MonoBehaviour
{
    public GameObject arSessionOrigin;
    public GameObject panelParent;

    private ARPlane[] aRPlanes;
    private ARPointCloud[] aRPointClouds;

    private PlaceOnPlane1 placeOnPlane1;
    private GameObject placedPrefab = null;
    private bool initOnce = false;

    private void Start()
    {
        panelParent.SetActive(true);
    }

    public void Image_Tracker_btn()
    {
        if(placedPrefab)
        {
            placedPrefab.SetActive(false);
        }
        arSessionOrigin.GetComponent<ARTrackedImageManager>().enabled = true;
        arSessionOrigin.GetComponent<ImageRecognition>().enabled = true;

        arSessionOrigin.GetComponent<ARPlaneManager>().enabled = false;
        arSessionOrigin.GetComponent<ARPointCloudManager>().enabled = false;
        arSessionOrigin.GetComponent<ARRaycastManager>().enabled = false;
        arSessionOrigin.GetComponent<PlaceOnPlane1>().enabled = false;
        panelParent.SetActive(false);

    }

    public void Ground_Plane_btn()
    {
        FindObjectOfType<PlaceOnPlane1>().ReScan();

        arSessionOrigin.GetComponent<ARPlaneManager>().enabled = true;
        arSessionOrigin.GetComponent<ARPointCloudManager>().enabled = true;
        arSessionOrigin.GetComponent<ARRaycastManager>().enabled = true;
        arSessionOrigin.GetComponent<PlaceOnPlane1>().enabled = true;

        arSessionOrigin.GetComponent<ARTrackedImageManager>().enabled = false;
        arSessionOrigin.GetComponent<ImageRecognition>().enabled = false;

        if(initOnce == false)
        {
            FindObjectOfType<PlaceOnPlane1>().Init();
            initOnce = true;
        }
        panelParent.SetActive(false);
    }

    public void ResetMenu()
    {
        panelParent.SetActive(true);

        arSessionOrigin.GetComponent<ARTrackedImageManager>().enabled = false;
        arSessionOrigin.GetComponent<ImageRecognition>().enabled = false;

        arSessionOrigin.GetComponent<ARPlaneManager>().enabled = false;
        arSessionOrigin.GetComponent<ARPointCloudManager>().enabled = false;
        arSessionOrigin.GetComponent<ARRaycastManager>().enabled = false;
        arSessionOrigin.GetComponent<PlaceOnPlane1>().enabled = false;

        FindObjectOfType<PlaceOnPlane1>().StopScan();
        FindObjectOfType<PlaceOnPlane1>().HideSpawn();
    }
}