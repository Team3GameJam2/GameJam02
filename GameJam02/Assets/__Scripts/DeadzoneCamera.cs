using UnityEngine;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(Camera))]
public class DeadzoneCamera : MonoBehaviour
{
    public Renderer target;
    public Rect deadzone;
    public Vector3 smoothPos;

    public Rect[] limits;

    protected DeadZonEditor rec;
    protected Camera _camera;
    protected Vector3 _currentVelocity;


    public void Start()
    {
        smoothPos = target.transform.position;
        smoothPos.z = transform.position.z;
        _currentVelocity = Vector3.zero;

        _camera = GetComponent<Camera>();
        if (!_camera.orthographic)
        {
            Debug.LogError("deadzone script require an orthographic camera!");
            Destroy(this);
        }
    }

    public void Update()
    {
        float localY = target.transform.position.y - transform.position.y;

        if (localY<deadzone.yMin)
        {
            smoothPos.y += localY - deadzone.yMin;
        }
        else if (localY > deadzone.yMax)
        {
            smoothPos.y += localY - deadzone.yMax;
        }

        Vector3 current = transform.position;
        current.x = smoothPos.x;
        current.y = smoothPos.y;
        transform.position = Vector3.SmoothDamp(current, smoothPos, ref _currentVelocity, 0.1f);
    }


    public void OnSceneGUI()
    {
        rec.OnSceneGUI();
    }


}