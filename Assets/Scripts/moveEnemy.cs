using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class moveEnemy : MonoBehaviour
{
    public float moveSpeed = 20.0f;
    public GameObject bang,bbang, instance;
    public AudioSource bubbleSound;
    bool flag = true;

    // Start is called before the first frame update
    void Awake()
    {
        bang = (GameObject)Resources.Load("Bang");
        bbang = (GameObject)Resources.Load("BBang");
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bubble")
        {
            GameObject.Find("MainScript").GetComponent<InitScene>().Score -= 10;
            instance = (GameObject)Instantiate(bang, transform.position, Quaternion.identity);
            bubbleSound.Play();
            Destroy(other.gameObject);
            Destroy(instance, 2f);

            if (GameObject.Find("MainScript").GetComponent<InitScene>().Score <= 0)
            {
                instance = (GameObject)Instantiate(bbang, transform.position, Quaternion.identity);
                Destroy(instance, 2f);
                Destroy(gameObject);
                GameObject.Find("MainScript").GetComponent<InitScene>().firstEnding();
            }       
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (flag == true)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            moveSpeed += 3.0f * Time.deltaTime;
            if (transform.position.x > 23f)
            {
                flag = false;
            }
        }
        else if (flag == false)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            moveSpeed += 3.0f * Time.deltaTime;
            if (transform.position.x < -21f)
            {
                flag = true;
            }
        }
    }
}
