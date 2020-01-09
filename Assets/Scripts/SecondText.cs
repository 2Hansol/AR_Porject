using System.Collections;
using System.Collections.Generic;
using Vuforia;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SecondText : MonoBehaviour
{
    public InputField InputText;
    public Text SecondStory;
    public GameObject StoryCanvas;
    public GameObject InputCanvas;
    public string story = null;
   
    // Start is called before the first frame update
    void Start()
    {
        StoryCanvas.SetActive(false);
    }
    // Update is called once per frame
 
    public void input()
    {
        story = InputText.text;
        SecondStory.text = story;
        InputCanvas.SetActive(false);
        StoryCanvas.SetActive(true);
    }
}
