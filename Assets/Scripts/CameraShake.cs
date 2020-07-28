using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    float mouseOffset = 0;
    Vector2 lastMouse = Vector2.zero;
    float time = 0;
    void Start()
    {
        lastMouse = Input.mousePosition;
    }

    void Update()
    {
        if (!IsMouseOverGameWindow)
            return;

        Vector2 c = Input.mousePosition;
        float dist = lastMouse.x - c.x;
        time += dist;
        var x = (Mathf.PerlinNoise(time / 300, 10) * 10.0f) - 5;
        var y = (Mathf.PerlinNoise((time) / 300, 100) * 10.0f) - 5;

        float rotSpeed = Input.GetMouseButton(0) ? 10 : 5;

      //  transform.position = new Vector3(x, 0, y);
        transform.Rotate(0, Time.deltaTime * rotSpeed*dist, 0);
        

        lastMouse = c;
    }

    bool IsMouseOverGameWindow { get { return !(0 > Input.mousePosition.x || 0 > Input.mousePosition.y || Screen.width < Input.mousePosition.x || Screen.height < Input.mousePosition.y); } }
}
