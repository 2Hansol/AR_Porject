using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ControlBubble : MonoBehaviour
{
    public GameObject prince, Center, bubble, instance;

 
    public void Attack()
    {
        bubble = (GameObject)Resources.Load("Bubble");
        Vector3 pos = new Vector3(Center.transform.position.x, Center.transform.position.y+ 13f, Center.transform.position.z);
        instance = (GameObject)Instantiate(bubble, pos, Quaternion.Euler(90,0,0));
        instance.GetComponent<Rigidbody>().AddForce(transform.forward*100, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "BackGround")
        {
            Destroy(gameObject, 0.5f);
        }
    }
}


