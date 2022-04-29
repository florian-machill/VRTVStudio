using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class TrackerCapture : MonoBehaviour
{
    private SteamVR_TrackedObject tracker;

    // Start is called before the first frame update
    void Start()
    {
        tracker = GetComponent<SteamVR_TrackedObject>();
        StartCoroutine("CaptureData");
    }

    IEnumerator CaptureData()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.02f);

            // Update UI
            TrackerData data = new TrackerData(transform.position, transform.rotation);
            TrackerUI.Instance.DisplayTrackingData(data);

            if (TrackerUI.Instance.ShouldSync())
            {
                // Send data
                UPDClient.Instance.SendTrackingData(data);
            }
        }
    }
}
