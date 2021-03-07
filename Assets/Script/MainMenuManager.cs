using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void PressPlay()
    {
        SceneManager.LoadScene("Scene/SampleScene", LoadSceneMode.Single);
    }
}
