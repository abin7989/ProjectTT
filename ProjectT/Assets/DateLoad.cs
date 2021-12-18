using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DateLoad : MonoBehaviour
{
    private UserDataBase dateinof;
    [SerializeField] private TextMeshProUGUI date;

    void Start()
    {
        dateinof = GameObject.Find("UserDataBase").GetComponent<UserDataBase>();

    }
    void Update()
    {
        date.SetText(dateinof.Date);
    }
}
