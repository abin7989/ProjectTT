using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
public class FriendInfo : MonoBehaviour
{
    public ClientInfo c;
    // Start is called before the first frame update
    void Start()
    {
        GetFriends();
    }

    private void GetFriends()
    {
        Debug.Log("ģ�� ���");
        foreach (Friend friend in SteamFriends.GetFriends())
        {

            Debug.Log(friend.Id);
        }
    }
}
