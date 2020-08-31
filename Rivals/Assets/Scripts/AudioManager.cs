using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource source;
    public AudioSource sfx;
    public AudioClip[] clips;


    public AudioClip cassetteLoad;
    public AudioClip cassetteClick;
    public AudioClip paper;
    public AudioClip scribble;
    public AudioClip entryClick;

    public TextMeshProUGUI nowPlaying;

    public Slider slider;
    private bool adjustingScrub;
    public bool paused;
    private bool playing;
    public bool clickOn;
    void Start()
    {
        instance = this;
        clearText();
        clickOn = true;
    }

    private void Update()
    {
        if (!adjustingScrub && playing)
        {
            slider.value = source.time;
            if (source.clip != null)
            {
                if (source.time >= source.clip.length)
                {
                    stopAudio();
                }
            }
            
        }
        if (paused)
        {
            source.Pause();
        }
    }

    public void playClip(AudioClip clip, float volume, int i)
    {
        paused = false;
        source.Stop();
        source.clip = clip;
        source.volume = volume;
        source.Play();
        playing = true;
        sfx.PlayOneShot(cassetteLoad,0.3f);
        setSlider(clip);
        setNowPlayingText(i);
    }

    public void setNowPlayingText(int i)
    {
        nowPlaying.text = "Now Playing: \n" + GameResources.instance.nowPlaying[i];
    }

    public void clearText()
    {
        nowPlaying.text = "";
    }

    public void playAudio()
    {
        paused = false;
        playing = true;
        source.Play();
    }

    public void pauseAudio()
    {
        paused = true;
    }

    public void stopAudio()
    {
        paused = false;
        playing = false;
        source.Stop();
        source.clip = null;
        slider.value = 0;
        clearText();
    }


    public void playClick()
    {
        sfx.PlayOneShot(cassetteClick,1f);
    }

    public void PlayPaper()
    {
        sfx.PlayOneShot(paper);
    }

    public void PlayScribble()
    {
        sfx.PlayOneShot(scribble);
    }

    public void setSlider(AudioClip audioclip)
    {
        slider.maxValue = audioclip.length;
        slider.value = 0;
    }

    public void changeAudioFromSlider()
    {
        source.Pause();
        source.time = slider.value;
        source.Play();
        adjustingScrub = false;
        
    }

    public void adjustScrub()
    {
        adjustingScrub = true;
    }
}
