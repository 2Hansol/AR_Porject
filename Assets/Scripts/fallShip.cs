using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class fallShip : MonoBehaviour
{

    private Quaternion Rightx = Quaternion.Euler(0, -90, 0);
    private Quaternion Leftx = Quaternion.Euler(0, -90, 0);
    private Quaternion Rightz = Quaternion.Euler(0, -90, 0);
    private Quaternion Leftz = Quaternion.Euler(0, -90, 0);

    // Start is called before the first frame update

    void Start()
    {

        Rightx.eulerAngles = new Vector3(60, -90, 0);
        Leftx.eulerAngles = new Vector3(-60, -90, 0);
        Rightz.eulerAngles = new Vector3(0, -90, 60);
        Leftz.eulerAngles = new Vector3(0, -90, -60);

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.rotation.x < 30)
            transform.rotation = Quaternion.Slerp(transform.rotation, Rightx, Time.deltaTime * 1.0f);
        if (gameObject.transform.rotation.x >= 30)
            transform.rotation = Quaternion.Slerp(transform.rotation, Leftx, Time.deltaTime * 1.0f);
        if (gameObject.transform.rotation.z < 30)
            transform.rotation = Quaternion.Slerp(transform.rotation, Rightz, Time.deltaTime * 1.0f);
        if (gameObject.transform.rotation.z >= 30)
            transform.rotation = Quaternion.Slerp(transform.rotation, Leftz, Time.deltaTime * 1.0f);

        /*
        if (transform.position.y <= 0.045)
        {
            transform.Translate(Vector3.down * 1.0f * Time.deltaTime);
        }*/
    }
}
