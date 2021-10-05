using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class GoogleData
{
    public string order, result, msg, SteamID;
}
public class SteamIDCheckData : MonoBehaviour
{
    public UserDataBase udb;
    //tsv�� ������ ������.
    const string URL = "https://script.google.com/macros/s/AKfycbzizdxpZZwsuW4pQ7WAXb99wCjjRRQ4JCdCPV7KuEra8AE0_acSgYihEMTevqAX4Cmr/exec";
    public GoogleData GD;
    // Start is called before the first frame update
    public void IDCheck()
    {
        WWWForm form = new WWWForm();
        form.AddField("order", "SteamIDCheck");
        form.AddField("steamID", udb.UserSteamID.ToString());
        StartCoroutine(Post(form));
    }

    IEnumerator Post(WWWForm form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form)) // �ݵ�� using�� ����Ѵ�
        {
            yield return www.SendWebRequest();

            if (www.isDone)
            {
                Debug.Log(www.downloadHandler.text);
                Debug.Log("ȣ�� �Ϸ�");
            }
            else print("���� ������ �����ϴ�.");
        }
    }
}
