using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    
    [SerializeField]
    private GameOverUI _gameOverUI;
    [SerializeField]
    private Player _player;
    private bool IsDeath = false;
    private Transform _firstPos;

    //properties
    #region
    public bool Death
    {
        set
        {
            if(value != IsDeath)
            {
                IsDeath = value;
                KillPlayer(IsDeath);  
            }
        }
        get { return IsDeath; }
    }

   
    #endregion

    //constructor
    public GameManager()
    {

    }

    private void Start()
    {
        _firstPos = _player.transform;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (_gameOverUI.isActiveAndEnabled)
            {
                _gameOverUI.BackMenu();
            }
            else
            {
                _gameOverUI.gameObject.SetActive(true);
            }

        }
    }


    public void KillPlayer(bool death)
    {
        if(death == true)
        {
            _player.transform.position = new Vector2(1000, -1000);
            Debug.Log("Player is death");
            _gameOverUI.gameObject.SetActive(true);
            Time.timeScale = 0f;
            CalculateTotalCoin();
           
        }
    }


  public static void CalculateTotalCoin()
    {
        Player.totalCoin = Player.totalCoin + Player._playerScore;
        Debug.Log("Player total coin: " +Player.totalCoin);

    }

    //functions
   



   


  


  
}
