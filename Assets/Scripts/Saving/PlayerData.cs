using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public float levelsCompleted;
    public bool redAnkhCollect;
    public bool blueAnkhCollect;
    public bool greenAnkhCollect;
    public bool whiteAnkhCollect;
    public bool redHelmetCollect;
    public bool blueHelmetCollect;
    public bool greenHelmetCollect;
    public bool whiteHelmetCollect;

    public PlayerData(PlayerInfo player)
    {
        levelsCompleted = player.levelsCompleted;

        redAnkhCollect = player.redAnkhCollect;
        blueAnkhCollect = player.blueAnkhCollect;
        greenAnkhCollect = player.greenAnkhCollect;
        whiteAnkhCollect = player.whiteAnkhCollect;
        redHelmetCollect = player.redHelmetCollect;
        blueHelmetCollect = player.blueHelmetCollect;
        greenHelmetCollect = player.greenHelmetCollect;
        whiteHelmetCollect = player.whiteHelmetCollect;

    }
}
