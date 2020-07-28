using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grpc.Core;
using POC3;
using System;
using UnityEngine.UI;
using System.Threading;

public class grpcClient : MonoBehaviour
{
    Channel channel;
    POC3Service.POC3ServiceClient client;
    public Transform AR_Camera;
    public string addr;
    private bool connected = false;

    private float timeout = 5;
    private bool WaitingToReconnect = false;

    void Start()
    {
        addr = PocAppSettings.TargetAddress;

        channel = new Channel(PocAppSettings.TargetAddress + ":" + PocAppSettings.Port, ChannelCredentials.Insecure);
        try
        {
            client = new POC3Service.POC3ServiceClient(channel);
        }
        catch (Exception e)
        {
            StartCoroutine(TimeoutCount());
            Debug.LogError(Time.time + ": " + e.Message);
        }
    }

    private IEnumerator TimeoutCount()
    {
        WaitingToReconnect = true;
        yield return new WaitForSeconds(timeout);
        WaitingToReconnect = false;
    }

    void Update()
    {
        if (WaitingToReconnect)
        {
            Debug.LogError("waiting to reconnect...");
            return;
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = AR_Camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    try
                    {
                        SpawnPosition p = new SpawnPosition
                        {
                            X = hit.point.x,
                            Y = hit.point.y,
                            Z = hit.point.z
                        };

                        var reply = client.SpawnSphere(p);
                    }
                    catch (Exception e)
                    {
                        //  StartCoroutine(TimeoutCount());
                        //  Debug.LogError(Time.time + ": " + e.Message);
                    }
                }
            }
                

            try
            {
                CameraOrientation o = new CameraOrientation
                {
                    X = AR_Camera.position.x,
                    Y = AR_Camera.position.y,
                    Z = AR_Camera.position.z,
                    Rx = AR_Camera.eulerAngles.x,
                    Ry = AR_Camera.eulerAngles.y,
                    Rz = AR_Camera.eulerAngles.z
                };

                var reply = client.SetCameraPosition(o);
            }
            catch (Exception e)
            {
              //  StartCoroutine(TimeoutCount());
              //  Debug.LogError(Time.time + ": " + e.Message);
            }
        }

    }
}
