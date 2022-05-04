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
            float waitTime = UDPClientUI.Instance.GetInterval() / 1000;
            yield return new WaitForSeconds(waitTime);

            // Update UI: Display data
            TrackerData data = new TrackerData(transform.position, transform.rotation);
            TrackerUI.Instance.DisplayTrackingData(data);

            if (UDPClientUI.Instance.ShouldSync())
            {
                // Send data
                UPDClient.Instance.SendTrackingData(data);
            }
        }
    }
}
