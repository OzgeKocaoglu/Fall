using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public Button _chameleonButton;
    public Button _angryPigButton;
    public Button _turtleButton;
    public Text _chameleon, _angrypig, _turtle;
    public Button _selectC, _selectA, _selectT, _selectS;
    public ShopManager _shopManager;
    public Text _coinAmount;
    public Text _playerName;

    private void Awake()
    {
        _playerName.text = Player._name;
    }
    private void Update()
    {
        _coinAmount.text = Player.totalCoin.ToString();
    }
    public void OnBackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnBuyButtonChameleon()
    {
       
        if (_shopManager.BuyChameleon())
        {
            _chameleonButton.gameObject.SetActive(false);
            _chameleon.gameObject.SetActive(true);


        }

    }

    public void OnBuyButtonTurtle()
    {
        if (_shopManager.BuyTurtle())
        {
            _turtleButton.gameObject.SetActive(false);
            _turtle.gameObject.SetActive(true);
        }
    }

    public void OnBuyButtonAngryPig()
    {
        if (_shopManager.BuyAngryPig())
        {
            _angryPigButton.gameObject.SetActive(false);
            _angrypig.gameObject.SetActive(true);
        }
    }


   

}
