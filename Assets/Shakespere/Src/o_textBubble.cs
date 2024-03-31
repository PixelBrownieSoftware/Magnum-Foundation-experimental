using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using System;
using TMPro;

//From: https://gist.github.com/aarthificial/d2064b363ab4244988c5866f23fa4d3a
public static class PlayableDirectorExtensions
{
    public static void Freeze(this PlayableDirector director)
    {
        director.playableGraph.GetRootPlayable(0).SetSpeed(0);
    }

    public static void Unfreeze(this PlayableDirector director)
    {
        director.playableGraph.GetRootPlayable(0).SetSpeed(1);
    }
}
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
        return director.state == PlayState.Paused;
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
                director.Unfreeze();
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
