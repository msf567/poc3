using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSettings : MonoBehaviour
{
    public GameObject cubePrefab;
    void Start()
    {
        GenerateCubes(PocAppSettings.CubeAmount);
    }

    void Update()
    {

    }

    public void GenerateCubes(int amt)
    {
        int cubes = 0;

        for (int y = -100; y < 100; y++)
        {
            if (cubes > amt)
                break;

            for (int z = -100; z < 100; z++)
            {
                if (cubes > amt)
                    break;
                for (int x = -100; x < 100; x++)
                {
                    if (cubes > amt)
                        break;

                    var c = Instantiate(cubePrefab, transform);
                    c.transform.localPosition = new Vector3(x / 5.0f, y / 5.0f, z / 5.0f);

                    cubes++;
                }
            }
        }
    }
}
