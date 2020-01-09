using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class SceneMangement : MonoBehaviour
{


    public void ChangeFirst()
    {
        SceneManager.LoadScene("First");
    }
    public void ChangeSecond()
    {
        SceneManager.LoadScene("Second");
    }
    public void ChangeSample()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
