using System.Net.Mail;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField] private Text currenttime;

    private float count;
    private bool time = false;

    void Update()
    {
        if(time == false)
        {
            time = true;
            StartCoroutine(time_1());
        }
    }

    IEnumerator time_1()
    {
        yield return new WaitForSeconds(1f);
        count += 1f;
        currenttime.text = "시간 : " + count;
        time = false;
    }

}
