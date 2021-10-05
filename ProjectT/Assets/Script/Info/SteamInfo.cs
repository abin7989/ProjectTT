using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class SteamInfo : MonoBehaviour
{
    [SerializeField] private ulong steamId;
    public UserDataBase udb;
    public SteamIDCheckData steamidCheck;
    // Start is called before the first frame update
    private void Awake()
    {
        try
        {
            Steamworks.SteamClient.Init(appid: 1737610);
            Debug.Log(message: "steam is runnig!");
        }
        catch(SystemException e)
        {
            Debug.Log(e);
        }
        steamId = (ulong)SteamClient.SteamId;
        udb.UserSteamID = steamId;
        udb.Username = SteamClient.Name;
    }
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Debug.Log("������ ����Ǿ����ϴ�.");
            SteamClient.Shutdown();
            ExitGame();
        }

    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }
}

