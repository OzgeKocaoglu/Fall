using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int _playerScore = 0;
    public static int totalCoin = 0;
    public static string _name;
    public GameObject _characterSlime, _characterTurtle, _characterChameleon, _characterAngryPig;
    public static bool _slime = true, _turtle = false, _chameleon = false, _angryPig = false;
    public GameObject _selectedCharacter;



    private void Awake()
    {
        _selectedCharacter = _characterSlime;
    }

    private void Update()
    {
        SetSelectedCharacter();
        ActivateCurrentCharacter();
        //Debug.Log("Current character is " + _selectedCharacter.name);
    }

    public void SetSelectedCharacter()
    {
        if (_turtle)
        {
            _selectedCharacter = _characterTurtle;
        }
        else if (_slime)
        {
            _selectedCharacter = _characterSlime;
        }
        else if (_chameleon)
        {
            _selectedCharacter = _characterChameleon;
        }
        else if (_angryPig)
        {
            _selectedCharacter = _characterAngryPig;
        }
    }

    public void ActivateCurrentCharacter()
    {
        if(_selectedCharacter == _characterSlime)
        {
            _characterSlime.SetActive(true);
            _characterTurtle.SetActive(false);
            _characterChameleon.SetActive(false);
            _characterAngryPig.SetActive(false);
        }
        else if(_selectedCharacter == _characterTurtle)
        {
            _characterSlime.SetActive(false);
            _characterTurtle.SetActive(true);
            _characterChameleon.SetActive(false);
            _characterAngryPig.SetActive(false);
        }
        else if(_selectedCharacter == _characterChameleon)
        {
            _characterSlime.SetActive(false);
            _characterTurtle.SetActive(false);
            _characterChameleon.SetActive(true);
            _characterAngryPig.SetActive(false);
        }
        else if(_selectedCharacter == _characterAngryPig)
        {
            _characterSlime.SetActive(false);
            _characterTurtle.SetActive(false);
            _characterChameleon.SetActive(false);
            _characterAngryPig.SetActive(true);
        }
    }

  


}
