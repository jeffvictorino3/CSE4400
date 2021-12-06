using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public GameObject loseMenu;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        loseMenu.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player == null)
        {
            LoseGame();
        }
    }

    public void LoseGame()
    {
        loseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RetryLose()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
}
