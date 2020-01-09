using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class moveShip : MonoBehaviour
{
    private float moveSpeed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > -1.5f)
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
