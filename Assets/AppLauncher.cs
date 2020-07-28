using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Bolt.Matchmaking;
using UdpKit;
using System;
using UnityEngine.SceneManagement;

public class AppLauncher : GlobalEventListener
{
    public override void BoltStartDone()
    {
        if (BoltNetwork.IsServer)
        {
            string matchName = Guid.NewGuid().ToString();

            BoltMatchmaking.CreateSession(
                sessionID: matchName,
                sceneToLoad: "ServerScene"
            );
        }
    }

    public void StartAsClient()
    {
        BoltLauncher.StartClient();
    }

    public void StartAsEdge()
    {
        SceneManager.LoadScene("EdgeScene");
    }

    public void StartAsServer()
    {
        BoltLauncher.StartServer();
    }

    public override void SessionListUpdated(Map<Guid, UdpSession> sessionList)
    {
        Debug.LogFormat("Session list updated: {0} total sessions", sessionList.Count);

        foreach (var session in sessionList)
        {
            UdpSession photonSession = session.Value as UdpSession;

            if (photonSession.Source == UdpSessionSource.Photon)
            {
                BoltMatchmaking.JoinSession(photonSession);
            }
        }
    }
}
