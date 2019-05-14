using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : MonoBehaviour {

    [SerializeField]GameObject NM;
    [SerializeField]GameObject notStop;
    [SerializeField]GameObject StopNow;
    private bool stopFlag;

    [SerializeField]SOUND sound;

    void Start () {
        stopFlag = false;
    }
	
    public void StopON()
    {
        if (stopFlag == false && Flags.instance.isPlayStart ==true)
        {
            sound.pauseBGM();
            NM.SetActive(false);
            Flags.instance.isPlayStart = false;
            notStop.SetActive(false);
            StopNow.SetActive(true);
            stopFlag = true;            
        }
        else if(stopFlag==true)
        {
            sound.againBGM();
            NM.SetActive(true);
            Flags.instance.isPlayStart = true;
            notStop.SetActive(true);
            StopNow.SetActive(false);
            stopFlag = false;
            NM.GetComponent<NumberManager>().Again();
        }
    }    
}
