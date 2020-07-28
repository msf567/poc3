using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
public class PocAppSettings : MonoSingleton<PocAppSettings>
{
    public static string MyAddress;
    public static string TargetAddress;
    public static int Port = 50051;
    public static int CubeAmount = 1000;
    public static Color SphereColor;
    private static PocAppSettings inst;

    public void Awake()
    {
        SetMyAddress();
        SphereColor = new Color(Random.value, Random.value, Random.value);
    }   

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (inst == null)
        {
            inst = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void SetPort(int p)
    {
        Port = p;
    }

    public static void SetAddress(string ip)
    {
        IPAddress ad;
        if (!IPAddress.TryParse(ip, out ad))
        {
            Debug.LogError("Ip address not valid: " + ip);
            return;
        }

        TargetAddress = ip;
        Debug.LogError("Setting target ip to " + ip);
    }

    public void SetMyAddress()
    {
        MyAddress = GetLocalIPAddress();
    }

    private static string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }

        throw new Exception("No network adapters with an IPv4 address in the system!");
    }

    string GetPublicIPAddress()
    {
        string address = "";
        WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
        using (WebResponse response = request.GetResponse())
        using (StreamReader stream = new StreamReader(response.GetResponseStream()))
        {
            address = stream.ReadToEnd();
        }

        int first = address.IndexOf("Address: ") + 9;
        int last = address.LastIndexOf("</body>");
        address = address.Substring(first, last - first);

        return address;
    }

}
