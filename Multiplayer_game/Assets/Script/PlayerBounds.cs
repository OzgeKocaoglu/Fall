using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{

    public float min_X = -10.9f, max_X = 10.9f, min_Y = -7.81f;
    public bool OUT_OF_BOUDS = false;
    [SerializeField]
    private GameManager _gameManager;
    

    // Update is called once per frame
    void Update()
    {
        CheckBounds();
    }

    void CheckBounds()
    {
        Vector2 temp = transform.position;

        if (temp.x > max_X)
            temp.x = max_X;

        if (temp.x < min_X)
            temp.x = min_X;
        transform.position = temp;

        if(temp.y <= min_Y)
        {
            if (!OUT_OF_BOUDS)
            {
                OUT_OF_BOUDS = true;
                _gameManager.Death = true;
                //SoundManager.Instance.DeathSound();
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "TopSprike" || collision.tag == "SprikePlatform")
        {
            _gameManager.Death = true;
            //SoundManager.instance.DeathSound();
            //GameManager.instance.FinishGame();
        }
    }
}
