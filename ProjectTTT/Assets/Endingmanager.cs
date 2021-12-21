using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Endingmanager : MonoBehaviour
{
    public UserDataBase udb;
    public TextMeshProUGUI o;
    public TextMeshProUGUI t;
    public FadeManager fader;
    public BGMmanager bgm;

    private void Awake()
    {
        udb = GameObject.Find("UserDataBase").GetComponent<UserDataBase>();
        fader = GameObject.Find("FadeManager").gameObject.GetComponent<FadeManager>();
        bgm = GameObject.Find("BGMmanager").gameObject.GetComponent<BGMmanager>();
    }

    private void Start()
    {
        bgm.bgm.mute = true;
        StartCoroutine(fader.FadeOutActiveate(fader));
        t.SetText(udb.Date);
        o.SetText(udb.Money.ToString());
    }
}
