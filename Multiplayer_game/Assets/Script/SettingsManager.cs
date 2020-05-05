using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    
    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
