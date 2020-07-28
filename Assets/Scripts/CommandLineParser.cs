using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CommandLine;

public class Options
{
    [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
    public bool Verbose { get; set; }

    [Option('s', "server", Required = false, HelpText = "Set server mode")]
    public bool ServerMode { get; set; }

    [Option('c', "client", Required = false, HelpText = "Set client mode")]
    public bool ClientMode { get; set; }

    [Option('e', "edge", Required = false, HelpText = "Set edge mode")]
    public bool EdgeMode { get; set; }

    [Option('i', "ipaddress", Required = false, HelpText = "Set target ip address")]
    public string IPAddress { get; set; }

    [Option('p', "port", Required = false, HelpText = "Set target port")]
    public int Port { get; set; }
}

public class CommandLineParser : MonoBehaviour
{
    bool clientMode = false;
    bool edgeMode = false;
    private void Start()
    {
        var args = Environment.GetCommandLineArgs();

        Parser.Default.ParseArguments<Options>(args)
                  .WithParsed<Options>(o =>
                  {
                      if (o.ServerMode)
                          clientMode = false;
                      if (o.ClientMode)
                          clientMode = true;
                      if (o.EdgeMode)
                          edgeMode = true;
                      if (o.IPAddress!= null)
                          PocAppSettings.SetAddress(o.IPAddress);
                      if (o.Port > 0)
                          PocAppSettings.SetPort(o.Port);
                  });

        if(edgeMode)
        {
            FindObjectOfType<AppLauncher>().StartAsEdge();
            return;
        }

        if (clientMode)
            FindObjectOfType<AppLauncher>().StartAsClient();
        else
            FindObjectOfType<AppLauncher>().StartAsServer();
    }

    
}
