using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct ScreenSize
{
    public int width { get; set; }
    public int height { get; set; }
};

public class MenuMangaer : MonoBehaviour
{
    public GameObject MenuTap;
    FullScreenMode screenMode;
    public List<Resolution> resolution = new List<Resolution>();//ȣȯ ���� ȭ�� ũ�� ����
    public List<ScreenSize> screenSizes = new List<ScreenSize>();
    public List<int> resolution_hz = new List<int>();

    public int resolutionNum;
    private void Awake()
    {
        resolution.AddRange(Screen.resolutions);
        resolution = resolution.ToList();
        foreach(var a in resolution)
        {
            ScreenSize c = new ScreenSize();
            c.width = a.width;
            c.height = a.height;

            screenSizes.Add(c);
        }
        screenSizes = screenSizes.ToList();

    }
    public void DropboxOptionChange(int _optionNum)
    {
        resolutionNum = _optionNum;
    }
    public void MenuConfirm()
    {
        Screen.SetResolution(screenSizes[resolutionNum].width,
            screenSizes[resolutionNum].height,
            screenMode);
        MenuTap.SetActive(false);
    }
    public void FullScreenChange(bool _isFull)
    {
        screenMode = _isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }
    public void StartMenu()
    {
        MenuTap.SetActive(true);
        Debug.Log("�޴� ����");
    }
    public void StopMenu()
    {
        MenuTap.SetActive(false);
        Debug.Log("�޴� ����");
    }


}
