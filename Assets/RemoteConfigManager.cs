using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteConfigManager : MonoBehaviour
{
    public int defaultLevelTime = 15;

    public static int levelTime { get; private set; }


    void Awake()
    {
        levelTime = defaultLevelTime;


        RemoteSettings.Completed += (b, b1, arg3) =>
        {
            levelTime = RemoteSettings.GetInt("ammoStandardSpeed", defaultLevelTime);
        };
    }
}