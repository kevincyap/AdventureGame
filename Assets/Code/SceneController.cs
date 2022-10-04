using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [HideInInspector]
    public static SceneController instance;
    public GameObject pauseMenu;
    void Start()
    {
        instance = this;
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !InventoryManager.instance.Inventory.activeSelf) //If the player presses the escape key
        {
            SetPauseMenu(!PublicVars.paused);
        }
    }
    public void HandleExit() {
        Application.Quit();
    }
    public void SetPauseMenu(bool pause) {
        SetPause(pause);
        pauseMenu.SetActive(pause);
    }
    public void SetPause(bool pause) {
        PublicVars.paused = pause;
        Time.timeScale = pause ? 0 : 1;
    }
}
