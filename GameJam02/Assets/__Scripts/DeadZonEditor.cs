using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DeadzoneCamera))]
public class DeadZonEditor : Editor
{
    public void OnSceneGUI()
    {
        DeadzoneCamera cam = target as DeadzoneCamera;
        

        Vector3[] vert =
        {
            cam.transform.position + new Vector3(cam.deadzone.xMin, cam.deadzone.yMin, 0),
            cam.transform.position + new Vector3(cam.deadzone.xMax, cam.deadzone.yMin, 0),
            cam.transform.position + new Vector3(cam.deadzone.xMax, cam.deadzone.yMax, 0),
            cam.transform.position + new Vector3(cam.deadzone.xMin, cam.deadzone.yMax, 0)
        };

        Color transp = new Color(0, 0, 0, 0);
        Handles.DrawSolidRectangleWithOutline(vert, transp, Color.red);

        for (int i = 0; i < cam.limits.Length; ++i)
        {
            Vector3[] vertLimit =
           {
                new Vector3(cam.limits[i].xMin, cam.limits[i].yMin, 0),
                new Vector3(cam.limits[i].xMax, cam.limits[i].yMin, 0),
                new Vector3(cam.limits[i].xMax, cam.limits[i].yMax, 0),
                new Vector3(cam.limits[i].xMin, cam.limits[i].yMax, 0)
            };

            Handles.DrawSolidRectangleWithOutline(vertLimit, transp, Color.green);
        }
    }
}