using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    float speed = 50.0f;
    GameObject go;
    Vector3 lookAt;

    // Use this for initialization
    void Start()
    {
        lookAt = new Vector3(0,0,0);
        transform.LookAt(lookAt);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 10000.0f))
            {
                if (hit.transform != null)
                {
                    go = hit.transform.gameObject;
                    lookAt = hit.transform.gameObject.transform.position;
                    transform.LookAt(lookAt);
                }
            }
        }

        transform.position += go.transform.position - lookAt;
        lookAt = go.transform.position;

        if (Input.GetMouseButton(1))
        {

            float mX = Input.GetAxis("Mouse X");
            float mY = Input.GetAxis("Mouse Y");

            transform.position += speed * Time.deltaTime * mX * (Vector3.Cross(transform.up, transform.forward).normalized)*Vector3.Magnitude(transform.position-lookAt)/100;
            transform.position += transform.up * speed * Time.deltaTime * mY;
            transform.LookAt(lookAt);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.position += scroll * Time.deltaTime * speed * 300 * transform.forward;
    }

}
