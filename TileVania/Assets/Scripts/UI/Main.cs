using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public GameObject sound;
    [SerializeField] GameObject re;

    public void GoMain()
    {
        Instantiate(sound);
        //re.gameObject.SetActive(true);
        SceneManager.LoadScene("Level 1");
    }
    
}
