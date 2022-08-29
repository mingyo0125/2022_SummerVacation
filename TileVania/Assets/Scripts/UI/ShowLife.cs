using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLife : MonoBehaviour
{
    [SerializeField] GameObject live1, live2, live3;
    public float life;
    void Start()
    {
        life = PlayerPrefs.GetFloat("live");

        if(life == 3)
        {
            live1.gameObject.SetActive(true);
            live2.gameObject.SetActive(true);
            live3.gameObject.SetActive(true);
        }
        if(life == 2)
        {
            live1.gameObject.SetActive(true);
            live2.gameObject.SetActive(true);
        }
        if(life == 1)
        {
            live1.gameObject.SetActive(true);
        }
    }

}
