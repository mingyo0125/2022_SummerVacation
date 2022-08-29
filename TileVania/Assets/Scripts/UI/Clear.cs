using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    [SerializeField] GameObject clearSound;
    [SerializeField] GameObject clear;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Instantiate(clearSound);
            StartCoroutine("Exit");
        }
    }

    IEnumerator Exit()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        clear.gameObject.SetActive(true);
    }
}
