using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteConfigManager : MonoBehaviour
{
    public int defaultLevelTime = 20;
    public int defaultRemaingTime = 5;

    public static int levelTime { get; private set; }
    public static int remaingTime { get; private set; }
    


    void Awake()
    {
        levelTime = defaultLevelTime;


        RemoteSettings.Completed += (b, b1, arg3) =>
        {
            levelTime = RemoteSettings.GetInt("levelTime", defaultLevelTime);
            remaingTime = RemoteSettings.GetInt("remaingTime", defaultRemaingTime);
        };
    }
}