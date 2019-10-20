using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    float speed = 50.0f;
    public GameObject go;
    Vector3 lookAt;


    public Vector3 startMarker;
    public Vector3 startLook;
    public float AnimSpeed = 1000.0F;
    private float startTime;
    private float journeyLength;
    public Transform target;
    public float smooth = 5.0F;
    private bool movement;
    private bool track;

    // Use this for initialization
    void Start()
    {
        lookAt = new Vector3(0, 0, 0);
        transform.LookAt(lookAt);
        track = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMarker = transform.position;
            startLook = transform.forward;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 10000.0f))
            {
                if (hit.transform != null)
                {
                    go = hit.transform.gameObject;
                    movement = true;
                    track = false;
                }
            }
            
            startTime = Time.time;
            
        }

        if (movement)
        {
            journeyLength = Vector3.Distance(startMarker, go.transform.position);
            float distCovered  = (Time.time - startTime) * AnimSpeed;
            float fracJourney  = 400*distCovered / journeyLength;
            
            transform.forward = Vector3.Lerp(startLook,(go.transform.position-transform.position).normalized, fracJourney);
            lookAt = go.transform.position;
            if (Vector3.Distance(transform.position, go.transform.position) > 100)
            {
                transform.position = Vector3.Lerp(startMarker, go.transform.position, fracJourney + 0.2f);
            }
            if (fracJourney > 1.0f)
            {
                track = true;
                movement = false;
            }
        }

        if (track && go)
        {
            transform.position += go.transform.position - lookAt;
            lookAt = go.transform.position;
            transform.LookAt(lookAt);
        }

        if (Input.GetMouseButton(1))
        {

            float mX = Input.GetAxis("Mouse X");
            float mY = Input.GetAxis("Mouse Y");

            transform.position += speed * Time.deltaTime * mX * (Vector3.Cross(transform.up, transform.forward).normalized) * Vector3.Magnitude(transform.position - lookAt) / 100;
            transform.position += transform.up * speed * Time.deltaTime * mY;
            transform.LookAt(lookAt);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.position += scroll * Time.deltaTime * speed * 300 * transform.forward;
    }

}



