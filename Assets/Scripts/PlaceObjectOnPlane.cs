using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;
using UnityEngine.UI;


[RequireComponent(typeof(ARPlaneManager))]
public class PlaceObjectOnPlane : MonoBehaviour 
{
    public GameObject placedPrefab;
    public GameObject textPrefab;
    private GameObject placedObject;
    private GameObject placedText;

    public Text Text_input_field;

    public ARPlaneManager planeManager;

    bool toPlace = true;

    int colliders = 0;

    public Camera cam;
    TextMeshPro textmeshPro;

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

    public void PlaceObj()
    {
        if(toPlace)
        {
            Instantiate(placedPrefab, cam.transform.position + cam.transform.forward, Quaternion.Euler(0, cam.transform.eulerAngles.y, 0));
        }
    }

    public void ToggleObjectPlacement()
    {
        toPlace = !toPlace;
    }

    public void PlaceText()
    {
        if (toPlace)
        {
            placedText = Instantiate(textPrefab, cam.transform.position + cam.transform.forward, Quaternion.Euler(0, cam.transform.eulerAngles.y, 0));
            
            var tmpTxt = placedText.transform.GetChild(1).gameObject;

            textmeshPro = tmpTxt.GetComponent<TextMeshPro>();
            string inputText = Text_input_field.text.ToString();
            if (string.IsNullOrWhiteSpace(inputText))
            {
                inputText = "Unknown Location";
            }
            textmeshPro.SetText(inputText);
        }
    }
}