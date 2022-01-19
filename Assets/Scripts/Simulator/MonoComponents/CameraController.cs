using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float moveSensitivity = 0.1f;
    [SerializeField]
    private float dragSensitivity = 4f;
    [SerializeField]
    private float scrollSensitivity = 0.1f;

    private CameraControllerData limits;

    [SerializeField]
    private Transform selectedUnitTransform;
    bool isTracking = false;

    private Vector3 dragOrigin;
    private Vector3 objectOrigin;
    private Vector3 defaultPos;
    private Vector3 defaultScale;

    void Start()
    {
        limits = new CameraControllerData(10f, 10f, 0.2f, 10f);
        defaultPos = transform.position;
        defaultScale = transform.localScale;
    }

    void Update()
    {
        Reset();
        Move();
        Drag();
        Zoom();
        Track();
        Bound();
    }

    void Bound()
    {
        if (transform.position.x < -limits.area.x)
        {
            transform.position = new Vector3(-limits.area.x, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > limits.area.x)
        {
            transform.position = new Vector3(limits.area.x, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -limits.area.y)
        {
            transform.position = new Vector3(transform.position.x, -limits.area.y, transform.position.z);
        }
        else if (transform.position.y > limits.area.y)
        {
            transform.position = new Vector3(transform.position.x, limits.area.y, transform.position.z);
        }
    }

    void Reset()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = defaultPos;
            transform.localScale = defaultScale;
        }
    }

    void Move()
    {
        if (Input.GetMouseButtonDown(1))
        {
            dragOrigin = Input.mousePosition;
        }
        if (Input.GetMouseButton(1))
        {
            Vector3 cursorPos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 moveTo = new Vector3(cursorPos.x * moveSensitivity * Time.deltaTime, cursorPos.y * moveSensitivity * Time.deltaTime, 0);
            transform.Translate(moveTo, Space.World);
        }
    }

    void Drag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            objectOrigin = transform.position;
            dragOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 offSet = dragOrigin - Camera.main.ScreenToViewportPoint(Input.mousePosition);
            transform.position = objectOrigin + offSet * dragSensitivity;
        }
    }

    void Zoom()
    {
        float deltaZoom = -Input.mouseScrollDelta.y * scrollSensitivity * Time.fixedDeltaTime;
        if (limits.zoom.Contains(transform.localScale.x + deltaZoom))
        {
            transform.localScale += new Vector3(deltaZoom, deltaZoom, deltaZoom);
        }
    }

    void Track()
    {
        if (Input.GetMouseButtonDown(0)
            || Input.GetMouseButtonDown(1)
            || Input.GetMouseButtonDown(2)
            || Input.GetKeyDown(KeyCode.Space)
            || (Input.GetKeyDown(KeyCode.F) && isTracking))
        { 
            isTracking = false; 
        }
        else if (Input.GetKeyDown(KeyCode.F)) isTracking = true;
        if (isTracking && selectedUnitTransform)
        {
            transform.position = new Vector3(selectedUnitTransform.position.x, selectedUnitTransform.position.y, transform.position.z);
        }
    }
}
