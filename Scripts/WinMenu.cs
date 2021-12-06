using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public GameObject winMenu;
    // Start is called before the first frame update
    void Start()
    {
        winMenu.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        winMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RetryWin()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
}
