using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoScale : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.localScale.x > 0.35f)
            transform.localScale -= new Vector3(0.02f, 0.02f, 0.02f);
    }
}
