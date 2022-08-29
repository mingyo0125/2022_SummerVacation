using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    private void Update()
    {
        Time.timeScale = 0;
    }

    public void GameStart()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
