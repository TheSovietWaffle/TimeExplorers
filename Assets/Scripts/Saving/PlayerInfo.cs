using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
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

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        levelsCompleted = data.levelsCompleted;
        redAnkhCollect = data.redAnkhCollect;
        blueAnkhCollect = data.blueAnkhCollect;
        greenAnkhCollect = data.greenAnkhCollect;
        whiteAnkhCollect = data.whiteAnkhCollect;
        redHelmetCollect = data.redHelmetCollect;
        blueHelmetCollect = data.blueHelmetCollect;
        greenHelmetCollect = data.greenHelmetCollect;
        whiteHelmetCollect = data.whiteHelmetCollect;

    }

}
