using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] Image live1, live2, live3;
    [SerializeField] GameObject gameover;
    [SerializeField] GameObject player;
    [SerializeField] GameObject timer;
    [SerializeField] Text currenttime;
    [SerializeField] GameObject startGame;
    [SerializeField] GameObject StopGame;
    [SerializeField] GameObject UI;
    [SerializeField] GameObject re;
    [SerializeField] GameObject clear;
    [SerializeField] GameObject exit;
    public float lives;
    public float count;
    private bool time = false;
    void Awake()
    {
        PlayerPrefs.SetFloat("live", lives);
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if(numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(gameover);
            DontDestroyOnLoad(UI);
            DontDestroyOnLoad(re);
            DontDestroyOnLoad(clear);
            DontDestroyOnLoad(exit);
        }
    }

    private void Start()
    {
        UI.gameObject.SetActive(true);
        if(lives == 3)
        {
            startGame.gameObject.SetActive(true);
            gameObject.SetActive(false);
            StopGame.SetActive(true);
        }
    }

    private void Update()
    {
        if(time == false)
        {
            time = true;
            StartCoroutine(time_1());
        }
    }

    public void PlayerDeath()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        lives--;
        int cuttentScenceIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(cuttentScenceIndex);
        PlayerPrefs.SetFloat("live", lives);

        if(lives == 2)
        {
            live3.gameObject.SetActive(false);
        }
        if(lives == 1)
        {
            live2.gameObject.SetActive(false);
        }
        if(lives == 0)
        {
            gameover.gameObject.SetActive(true);
            player.gameObject.SetActive(false);
            timer.gameObject.SetActive(false);
            live1.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        lives = 3;
        Time.timeScale = 1;
        timer.gameObject.SetActive(true);
        live1.gameObject.SetActive(true);
        live2.gameObject.SetActive(true);
        live3.gameObject.SetActive(true);
        player.gameObject.SetActive(true);
        currenttime.text = "";
        count = 0;
    }

    public IEnumerator time_1()
    {
        yield return new WaitForSeconds(1f);
        count += 1f;
        currenttime.text = "Time : " + count;
        PlayerPrefs.SetFloat("time", count);
        time = false;
    }

    public void Clear()
    {
        timer.gameObject.SetActive(false);
        Time.timeScale = 0;
        SceneManager.LoadScene("Level 1");
    }


}
