using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;

[BoltGlobalBehaviour]
public class NetworkCallbacks : GlobalEventListener
{
    public override void SceneLoadLocalDone(string scene)
    {
        var spawnPosition = new Vector3(Random.Range(-8, 8), 0, Random.Range(-8, 8));

        if (BoltNetwork.IsClient)
        {
            BoltNetwork.Instantiate(BoltPrefabs.Cube, spawnPosition, Quaternion.identity);
        }
    }

    List<string> logMessages = new List<string>();

    public override void OnEvent(LogEvent evnt)
    {
        logMessages.Insert(0, evnt.Msg);
    }

    public void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            if (BoltNetwork.IsServer)
            {
                var spawnPosition = new Vector3(Random.Range(-8, 8), 0, Random.Range(-8, 8));
                BoltNetwork.Instantiate(BoltPrefabs.Sphere, spawnPosition, Quaternion.identity);
            }
        }
    }

    void OnGUI()
    {
        // only display max the 5 latest log messages
        int maxMessages = Mathf.Min(5, logMessages.Count);

        GUILayout.BeginArea(new Rect(Screen.width / 2 - 200, Screen.height - 100, 400, 100), GUI.skin.box);

        for (int i = 0; i < maxMessages; ++i)
        {
            GUILayout.Label(logMessages[i]);
        }

        GUILayout.EndArea();
    }
}
