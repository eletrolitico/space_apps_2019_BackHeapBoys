using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    float speed = 50.0f;
    Vector3 lookAt;

    // Use this for initialization
    void Start()
    {
        lookAt = new Vector3(0,0,0);
        transform.LookAt(lookAt);
    }

    void center(Vector3 v)
    {
        lookAt.Set(v.x,v.y,v.z);
        transform.LookAt(lookAt);
    }

    void center(float x,float y, float z)
    {
        lookAt.Set(x, y, z);
        transform.LookAt(lookAt);
    }

    void Update()
    {
        float mX = Input.GetAxis("Mouse X");
        float mY = Input.GetAxis("Mouse Y");
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        transform.position += speed * Time.deltaTime * mX * (Vector3.Cross(transform.up, transform.forward).normalized);
        transform.position += transform.up * speed * Time.deltaTime * mY;
        transform.LookAt(lookAt);

        transform.position += scroll * Time.deltaTime * speed * transform.forward;
    }

}
