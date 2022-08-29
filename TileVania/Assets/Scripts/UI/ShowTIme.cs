using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowTIme : MonoBehaviour
{
    [SerializeField] Text time;
    float _time;
    private void Update()
    {
        _time = PlayerPrefs.GetFloat("time");
        time.text = "Time : " + _time;
    }
}
