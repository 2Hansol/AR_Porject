using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class VirtualButton : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject gCube;    //이미지 타켓 밑에 빨간큐브
    public Material mPlayOn;      
    public Material mPlayOff;       
    public AudioSource UnderTheSea;
    void Start()
    {
        this.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }
    void OnDissable()
    {
        this.GetComponent<VirtualButtonBehaviour>().UnregisterEventHandler(this);
    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (UnderTheSea.mute == true){
            UnderTheSea.mute = false;
        }else{
            UnderTheSea.Play();
        }
        gCube.GetComponent<Renderer>().material = mPlayOn;
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        UnderTheSea.mute = true;
        gCube.GetComponent<Renderer>().material = mPlayOff;
    }
}
