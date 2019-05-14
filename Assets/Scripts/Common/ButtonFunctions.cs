using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour {
    
    public void PLAYGAME() {
        SceneManager.LoadScene("Play");
    }

    public void SETTING()
    {
        SceneManager.LoadScene("Setting");
    }

    public void TITLEBACK()
    {
        SceneManager.LoadScene("Title");
    }

    public void RESET()
    {
        SceneManager.LoadScene("Play");
    }
    
}
