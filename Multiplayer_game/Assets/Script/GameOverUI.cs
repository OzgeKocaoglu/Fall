using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{

    [SerializeField]
    private Text _currentscoreText;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            _currentscoreText.text = ((int)Player._playerScore).ToString();
        }
    }


    public void Restart()
    {
        Debug.Log("PlayerRespawing");
        this.gameObject.SetActive(false);
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1f;
        Player._playerScore = 0;

    }

    public void BackMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        Player._playerScore = 0;
    }
}
