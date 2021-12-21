using System.Collections;
using System.Collections.Generic;
using Steamworks.Data;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class TutorialManager : MonoBehaviour
{
    public List<Image> tuto;
    public GameObject tutortap;
    private int tutoNum = 0;

    void Start()
    {
        tuto[tutoNum].gameObject.SetActive(true);
    }

    public void TutoStart()
    {
        tutortap.SetActive(true);
    }
    public void TutoStop()
    {
        tutortap.SetActive(false);
    }
    public void ButtonUp()
    {
        tuto[tutoNum].gameObject.SetActive(false);
        if (tutoNum < tuto.Count-1)
        {
            tutoNum += 1;
        }
        else
        {
            tutoNum = 0;
        }
        tuto[tutoNum].gameObject.SetActive(true);
    }
    public void ButtonDown()
    {
        tuto[tutoNum].gameObject.SetActive(false);
        if (tutoNum > 0)
        {
            tutoNum -= 1;
        }
        else
        {
            tutoNum = tuto.Count-1;
        }
        tuto[tutoNum].gameObject.SetActive(true);
    }
}
