using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;


public class VideoPlay : MonoBehaviour, ITrackableEventHandler
{
    public GameObject videoPlayer, Playvideo_button, Pausevideo_button, Stopvideo_button;

    protected TrackableBehaviour mTrackableBehaviour;
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
        newStatus == TrackableBehaviour.Status.TRACKED ||
        newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            if (mTrackableBehaviour.TrackableName == "ww1")
            {
                videoPlayer.GetComponent<VideoPlayer>().Play();
                Playvideo_button.SetActive(false);

            }
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED && newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            videoPlayer.GetComponent<VideoPlayer>().Stop();
            OnTrackingLost();
        }
        else
        {
            OnTrackingLost();
        }
    }
    protected virtual void OnTrackingFound()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;
    }

    protected virtual void OnTrackingLost()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;
    }

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)){
                //case 1
                if (hit.collider.tag == "PlayVideo"){
                    videoPlayer.GetComponent<VideoPlayer>().Play();
                    Playvideo_button.SetActive(false);
                    Pausevideo_button.SetActive(true);
                    Stopvideo_button.SetActive(true);
                }

                //case 2
                if (hit.collider.tag == "StopVideo"){
                    videoPlayer.GetComponent<VideoPlayer>().Stop();
                    Playvideo_button.SetActive(true);
                    Pausevideo_button.SetActive(true);
                    Stopvideo_button.SetActive(false);
                }

                //case 3
                if (hit.collider.tag == "PauseVideo"){
                    videoPlayer.GetComponent<VideoPlayer>().Pause();
                    Playvideo_button.SetActive(true);
                    Pausevideo_button.SetActive(false);
                    Stopvideo_button.SetActive(true);
                }
            }
        }
    }
}