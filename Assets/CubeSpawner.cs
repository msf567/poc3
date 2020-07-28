using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    Camera cam;
    Color cubeColor;

    void Start()
    {
        cubeColor = new Color(Random.value, Random.value, Random.value);
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (BoltNetwork.IsClient)
        {
            if (Input.GetMouseButtonDown(0))
                SpawnCube();
        }
    }

    private void SpawnCube()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            var obj = BoltNetwork.Instantiate(BoltPrefabs.Sphere, hit.point, Quaternion.identity);
        }
    }
}
