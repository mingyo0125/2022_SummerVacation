using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScene : MonoBehaviour
{
    public void GoPlay()
    {
        SceneManager.LoadScene("Level 1");
    }
}
