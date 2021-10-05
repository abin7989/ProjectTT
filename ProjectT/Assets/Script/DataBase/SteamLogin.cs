using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;

public class SteamLogin : MonoBehaviour
{
    public UserDataBase udb;
    // Start is called before the first frame update
    void Start()
    {
        var reset = Backend.Initialize(true);
        if (reset.IsSuccess())
        {
            BackendReturnObject SteamLogin = Backend.BMember.CustomLogin(udb.Username, udb.UserSteamID.ToString());
            if (SteamLogin.IsSuccess())
            {
                Debug.Log("�α��ο� �����߽��ϴ�");
                BackendReturnObject bro = Backend.BMember.GetUserInfo();
                udb.UserSeverID = bro.GetReturnValuetoJSON()["row"]["gamerId"].ToString();
                udb.UserSeverInDate = bro.GetReturnValuetoJSON()["row"]["inDate"].ToString();
            }
            else if(int.Parse(SteamLogin.GetStatusCode())==401)
            {
                BackendReturnObject SteamSignUp = Backend.BMember.CustomSignUp(udb.Username, udb.UserSteamID.ToString());
                if (SteamSignUp.IsSuccess())
                {
                    Debug.Log("ȸ�����Կ� �����߽��ϴ�");
                    BackendReturnObject bro = Backend.BMember.GetUserInfo();
                    udb.UserSeverID = bro.GetReturnValuetoJSON()["row"]["gamerId"].ToString();
                }
            }else
            {
                Debug.Log("���� ����");
            }
        }
        else
        {
            // �ʱ�ȭ ���� �� ����
            Debug.Log("���� �ʱ�ȭ ����");
                
        }
    }

}
