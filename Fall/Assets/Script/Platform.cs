using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float bound_y = 6f;

    public bool is_Platform, is_Spike;

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 temp = transform.position;
        temp.y += moveSpeed * Time.deltaTime;
        transform.position = temp;

        if(temp.y > bound_y)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (is_Spike)
            {
                collision.transform.position = new Vector2(1000f, 1000f);
                //SoundManager.Instance.GameOverSound();
                //GameManager.Instance.RestartGame();
            }
            
             
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (is_Platform)
            {
               
                //SoundManager.instance.LandSound();
                
            }

        }
    }

    
    


}
