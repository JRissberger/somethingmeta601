using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject controls;
    public void LoadGame()
    {
        SceneManager.LoadScene("Office");
    }

    //Toggles the control menu
    public void ControlsToggle()
    {
        controls.SetActive(!controls.activeSelf);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
