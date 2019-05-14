using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SOUND : MonoBehaviour {
    
    private int BGMvolume = 0;

    [SerializeField] AudioClip BGM1;

    [SerializeField] AudioClip goodSE;
    [SerializeField] AudioClip badSE;
    [SerializeField] AudioClip clearSE;

    //0はBGM、１はSE
    private AudioSource[] audioSources;
    
    void Awake()
    {
        audioSources = GetComponents<AudioSource>();
    }
    
    public void playBGM()
    {
        if (STAT.instance.BGMFlag)
        {
            StopCoroutine("BGMFadeout");
            audioSources[0].clip = BGM1;
            StartCoroutine("BGMFadein");
            audioSources[0].Play();
        }
    }

    public void stopBGM()
    {
        StopCoroutine("BGMFadein");
        StartCoroutine("BGMFadeout");        
    }

    public void pauseBGM()
    {
        audioSources[0].Pause();
    }
    public void againBGM()
    {
        if (STAT.instance.BGMFlag)
        {
            audioSources[0].Play();
        }
    }

    IEnumerator BGMFadein()
    {
        for (; BGMvolume < 100; BGMvolume++)
        {
            audioSources[0].volume = (float)BGMvolume / 100;
            yield return null;
        }
    }

    IEnumerator BGMFadeout()
    {
        for (; BGMvolume > 0; BGMvolume--)
        {
            audioSources[0].volume = (float)(BGMvolume) / 100;
            yield return null;
        }
        audioSources[0].volume = 0;
    }

    public void GoodSE()
    {
        if (STAT.instance.SEFlag)
        {
            audioSources[1].PlayOneShot(goodSE);
        }
    }

    public void BadSE()
    {
        if (STAT.instance.SEFlag)
        {
            audioSources[1].PlayOneShot(badSE);

        }
    }

    public void ClearSE()
    {
        if (STAT.instance.SEFlag)
        {
            audioSources[1].PlayOneShot(clearSE);
        }
    }


}