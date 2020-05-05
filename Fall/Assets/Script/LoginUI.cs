using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginUI : MonoBehaviour
{

    public string _playerName;
   public void PlayButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Text_Change(string newText)
    {
        
    }
}
