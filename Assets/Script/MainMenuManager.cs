using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject creditOverlay;

    public void PressPlay()
    {
        SceneManager.LoadScene("Scene/Level1", LoadSceneMode.Single);
    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }

    public void ToggleCreditOverlay(bool show)
    {
        creditOverlay.SetActive(show);
    }
}
