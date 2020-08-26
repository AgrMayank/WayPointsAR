using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARPlaneManager))]
public class PlaceObjectOnPlane : MonoBehaviour 
{
    public GameObject placedPrefab;
    private GameObject placedObject;

    public ARPlaneManager planeManager;

    bool toPlace = true;

    int colliders = 0;

    public Camera cam;

    private void Awake() 
    {
        planeManager = GetComponent<ARPlaneManager>();
        planeManager.planesChanged += PlaneChanged;
    }

    private void PlaneChanged(ARPlanesChangedEventArgs args)
    {
        if(args.added != null && placedObject == null)
        {
            placedObject = Instantiate(placedPrefab, cam.transform.position + cam.transform.forward, Quaternion.Euler(0, cam.transform.eulerAngles.y, 0));
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        // colliders++;
        // PlaceObj();
    }

    void OnTriggerExit(Collider collider)
    {
        // colliders--;
        // PlaceObj();
    }

    // void Update() 
    // {
        // PlaceObj();
    // }

    public void PlaceObj()
    {
        if(toPlace)
        {
            // Vector3 Dist = Camera.main.transform.position - placedObject.transform.position;

            // if(Mathf.Abs(Dist.x) >= 1.5f || Mathf.Abs(Dist.z) >= 1.5f)
            // {
                Instantiate(placedPrefab, cam.transform.position + cam.transform.forward, Quaternion.Euler(0, cam.transform.eulerAngles.y, 0));
            // }
        }
    }

    public void ToggleObjectPlacement()
    {
        toPlace = !toPlace;
    }

}