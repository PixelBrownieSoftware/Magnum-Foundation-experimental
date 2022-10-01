using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using System;
using TMPro;

public class o_textBubble : MonoBehaviour
{
    public TextMeshProUGUI text;
    private string m_lastText;
    private  float m_timer = 0f;

    public PlayableDirector director;
    public AudioClip sound;
    public AudioSource audioMan;

    [SerializeField]
    private Image border;

    private void Awake()
    {
        border.color = Color.clear;
    }

    public void ShowText()
    {
        border.color = Color.white;
    }

    public void ClearText() {
        text.text = "";
        border.color = Color.clear;
    }

    public bool directorPaused() {
        return director.timelinePaused();
    }

    public void PauseDirector() {
        director.Freeze();
    }

    public void TypeVoice(float pitch, AudioClip voice) {
        if (text.text != m_lastText)
        {
            m_lastText = text.text;
            audioMan.pitch = pitch;
            if(voice != null)
                audioMan.PlayOneShot(voice);
            else
                audioMan.PlayOneShot(sound);
        }
    }

    private void Update()
    {
        if (m_timer > 0) {
            m_timer = m_timer - Time.deltaTime;
            if (m_timer <= 0) {
                director.UnFreeze();
            }
        }
        transform.rotation = Quaternion.identity;
    }

    public void PauseDialogueForTime(float t) {
        if (m_timer <= 0)
        {
            PauseDirector();
            m_timer = t;
            Debug.Log("ff");
        }
    }
    
}
