﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{

    public Text _playerName;
    public Text _coinAmount;

    private void Awake()
    {
        _playerName.text = Player._name;
    }
    private void Update()
    {
        _coinAmount.text = Player.totalCoin.ToString();

    }

    public void StartButton()
    {
            SceneManager.LoadScene("Game");
    }

    public void SettingsButton()
    {
        SceneManager.LoadScene("Settings");
    }

    public void ShopButton()
    {
        SceneManager.LoadScene("Shop");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
   
}
