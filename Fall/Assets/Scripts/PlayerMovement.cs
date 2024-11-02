using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D myBody;
    public float moveSpeed = 1f;

#if UNITY_ANDROID && !UNITY_EDITOR
    protected Joystick _joystick;
    protected JoyButton _joybutton;
#endif

    private AudioSource _audio;

    public bool IsOnGround = false;

    private void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        _joystick = FindObjectOfType<Joystick>();
        _joybutton = FindObjectOfType<JoyButton>();
#endif
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
#if UNITY_ANDROID && !UNITY_EDITOR
        myBody.velocity = new Vector2(_joystick.Horizontal * 20f, myBody.velocity.y);

        if(_joybutton.Pressed && IsOnGround)
        {
            myBody.velocity += Vector2.up * 2f;
            _audio.Play();
        }
#else
        myBody.velocity = new Vector2(Input.GetAxis("Horizontal") * 20f, myBody.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && IsOnGround)
        {
            myBody.velocity += Vector2.up * 2f;
            _audio.Play();
        }
#endif

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
        }
    }


    void AddScore()
    {
        Player._playerScore++;
        Debug.Log("Player Score: " + Player._playerScore);
    }
}
