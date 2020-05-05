using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClickSound : MonoBehaviour
{
    public AudioClip _buttonSound;

    private Button _button { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }


    private void Awake()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = _buttonSound;
        source.playOnAwake = false;
    }

    void Start()
    {

        _button.onClick.AddListener(() => PlaySound());
    }



    void PlaySound()
    {
        source.PlayOneShot(_buttonSound);
    }
}
