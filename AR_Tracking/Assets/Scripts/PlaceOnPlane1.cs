using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceOnPlane1 : MonoBehaviour
{
    [SerializeField]
    public GameObject placedPrefab;

    private GameObject PlacedPrefab
    {
        get
        {
            return placedPrefab;
        }
        set
        {
            placedPrefab = value;
        }
    }

   private ARRaycastManager arRaycastManager;
    List<ARRaycastHit> s_Hits;

    public GameObject spawnedObject { get; private set;}
    private ARPlane[] arplanes = null;
    private ARPointCloud[] arpoints = null;
    ARSessionOrigin m_SessionOrigin;

    // Start is called before the first frame update
    public void Init()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        s_Hits = new List<ARRaycastHit>();
    }

    private bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return; 
        if(arRaycastManager.Raycast(touchPosition, s_Hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            var hitPose = s_Hits[0].pose;

            if(spawnedObject == null)
            {
                spawnedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
                StopScan();
            }
        }
    }

    public void StopScan()
    {
        arplanes = FindObjectsOfType<ARPlane>();
        for(int i = 0; i < arplanes.Length; i++)
        {
            arplanes[i].gameObject.SetActive(false);
        }
        arpoints = FindObjectsOfType<ARPointCloud>();
        for(int i = 0; i <arpoints.Length; i++)
        {
            arpoints[i].gameObject.SetActive(false);
        }
    }

    public void ReScan()
    {
       if (arplanes.Length > 0)
        {
            for (int i = 0; i < arplanes.Length; i++)
            {
                arplanes[i].gameObject.SetActive(true);
            }
        }

        if (arpoints.Length > 0)
        {
            for (int i = 0; i < arpoints.Length; i++)
            {
                arpoints[i].gameObject.SetActive(true);
            }
        }
    }

    public void HideSpawn()
    {
        if (spawnedObject)
        {
            Destroy(spawnedObject);
        }
    }
}
