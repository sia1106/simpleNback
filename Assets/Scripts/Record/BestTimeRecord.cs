using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestTimeRecord : MonoBehaviour {
    
    [SerializeField]Text recoedText;
    [SerializeField] Text recoedTextN;
    [SerializeField] GameObject backGroundForText;
    
    public void OnClickBestTime()
    {
        backGroundForText.SetActive(true);
        
        int count=0;
        recoedText.text = "\n";
        recoedTextN.text = "BestTime\n";        

        foreach (float tim in STAT.instance.bestTime)
        {
            string temp = "";
            if (tim >= 300f)
            {
                temp = "- - -";
            }
            else
            {
                temp = tim.ToString("F1")+"s";
            }
            recoedTextN.text += "N=" + count + "\n";
            recoedText.text +=  "        " + temp + "\n";
            count++;
        }
    }

    public void UnClick()
    {
        recoedText.text = "";
        recoedTextN.text = "";
        backGroundForText.SetActive(false);
    }
}