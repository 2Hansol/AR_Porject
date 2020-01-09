using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class InitScene : MonoBehaviour
{

    public int Score = 100;
    public float Timer;
    public int seconds;
    public Text Score_T;

    public Text Time_T;
    private float CheckTime;

    public GameObject BackGround1, BackGround2, Center;
    public GameObject BasicCanvas; 
    public GameObject LoseMessage;
    public GameObject WinEndingCanvas;
    public GameObject Enemy;
    public GameObject jump;

    // Start is called before the first frame update
    void Start()
    {
        Timer = 30.0f;
        CheckTime = 2.0f;
        WinEndingCanvas.SetActive(false);
        jump.SetActive(false);
        LoseMessage.SetActive(false);
    }

    // Update is called once per frames
    void Update()
    {
        Score_T.text = "LIFE : "+ Score.ToString();

        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
            seconds = (int)(Timer % 60);
        }
        else
        {

            loseEnding();
            if(CheckTime > 0)
            {
                CheckTime -= Time.deltaTime;
            }
            else
            {
                GameObject.Find("MainScript").GetComponent<SceneMangement>().ChangeSample();
            }
           
        }
   
        Time_T.text = "TIME : " + seconds.ToString();
    }

    public void attack()
    {
        GameObject.Find("Bubble").GetComponent<ControlBubble>().Attack();
    }

    public void firstEnding()
    {
        BackGround1.SetActive(false);
        BackGround2.SetActive(false);

        BasicCanvas.SetActive(false);
        Center.SetActive(false);
        WinEndingCanvas.SetActive(true);
        jump.SetActive(true);

    }
    public void loseEnding()
    {
        BackGround1.SetActive(false);
        BackGround2.SetActive(false);

        Center.SetActive(false);
        Enemy.SetActive(false);
        LoseMessage.SetActive(true);
    }
}
