using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    public Text enemiesLeft;
    // Start is called before the first frame update
    void Start()
    {
        enemiesLeft.text = "Enemies Left: " + GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    // Update is called once per frame
    void Update()
    {
        enemiesLeft.text = "Enemies Left: " + GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
}
