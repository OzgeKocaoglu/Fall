using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D myBody;
    public float moveSpeed = 1f;
    protected Joystick _joystick;
    protected JoyButton _joybutton;
    private AudioSource _audio;

    public bool IsOnGround = false;

    private void Start()
    {
        _joystick = FindObjectOfType<Joystick>();
        _joybutton = FindObjectOfType<JoyButton>();
        _audio = FindObjectOfType<AudioSource>();
    }
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myBody.freezeRotation = true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        myBody.velocity = new Vector2(_joystick.Horizontal * 20f, myBody.velocity.y);

        if(_joybutton.Pressed && IsOnGround)
        {
                myBody.velocity += Vector2.up * 2f;
            _audio.Play();

        }

    }

    public void PlatformMove(float x)
    {
        myBody.velocity = new Vector2(x, myBody.velocity.y);
    }


    private void OnCollisionStay2D(Collision2D collision)
    {

        //Debug.Log("İcerideyim!");
        if (collision.gameObject.tag == "Platform")
        {
            IsOnGround = true;
        }
        else
        {
            IsOnGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Platform")
        {
            AddScore();
        }
        else
        {
            IsOnGround = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            IsOnGround = false;
            Debug.Log("Çıkıyorum");
        }
 
    }


    void AddScore()
    {
        Player._playerScore++;
        Debug.Log("Player Score: " + Player._playerScore);
    }





}
