using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using POC3;
using Grpc.Core;
using System.Threading.Tasks;
using UnityEngine.UI;

public class grpcServer : MonoBehaviour
{
    Server server;
    private string Host;
    public Text ipText;
    private static Vector3 cameraPos;
    private static Vector3 cameraRot;
    private static bool connected = false;
    private static bool newPosRecv = false;
    private static bool shouldSpawnSphere = false;
    private static Vector3 spawnPos;

    float lastTime = 0;

    public Transform RenderCamera;

    void Start()
    {
        if (BoltNetwork.IsClient)
        {
            Host = PocAppSettings.MyAddress.ToString();
            StartServer();
            ipText.text = "Broadcasting on " + Host;
        }
        else
            ipText.text = "" + Host;
    }

    void StartServer()
    {
        Debug.Log("Starting server");
        Server server = new Server
        {
            Services = { POC3Service.BindService(new CameraPosImpl()) },
            Ports = { new ServerPort(Host, PocAppSettings.Port, ServerCredentials.Insecure) }
        };

        server.Start();
    }

    private void Update()
    {
        if (!connected)
            return;

        if (newPosRecv)
        {
            float thisTime = Time.time * 1000;
            float dif = thisTime - lastTime;
            Debug.Log("Received camera position at " + Time.time * 1000 + " ms with a delta of " + dif + " ms");
            lastTime = thisTime;
            newPosRecv = false;
        }

        if (shouldSpawnSphere)
        {
            shouldSpawnSphere = false;
            var obj = BoltNetwork.Instantiate(BoltPrefabs.Sphere, spawnPos, Quaternion.identity);
        }

        RenderCamera.position = cameraPos;
        RenderCamera.eulerAngles = cameraRot;

        //SpherePos = ballGO.transform.position;
    }



    class CameraPosImpl : POC3Service.POC3ServiceBase
    {
        public override Task<SetReply> SetCameraPosition(CameraOrientation o, ServerCallContext context)
        {
            cameraPos = new Vector3(o.X, o.Y, o.Z);
            cameraRot = new Vector3(o.Rx, o.Ry, o.Rz);
            connected = true;
            newPosRecv = true;

            return base.SetCameraPosition(o, context);
        }

        public override Task<SetReply> SpawnSphere(SpawnPosition p, ServerCallContext context)
        {
            spawnPos = new Vector3(p.X, p.Y, p.Z);
            shouldSpawnSphere = true;
            return base.SpawnSphere(p, context);
        }
    }

    private void OnDisable()
    {
        StopServer();
    }

    private void OnApplicationQuit()
    {
        StopServer();
    }

    void StopServer()
    {
        server?.ShutdownAsync().Wait();
    }

}
