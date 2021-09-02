using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class SteamInfo : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(target: this);
        try
        {
            Steamworks.SteamClient.Init(appid: 1737610);
            Debug.Log(message: "steam is runnig!");
        }
        catch(SystemException e)
        {
            Debug.Log(e);
        }
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

