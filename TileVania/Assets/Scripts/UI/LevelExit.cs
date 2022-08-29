using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] GameObject clearSound;
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
        int cuttentScenceIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = cuttentScenceIndex + 1;

        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
