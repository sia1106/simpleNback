using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintPanelSwitch : MonoBehaviour {

    [SerializeField] NumberManager NB;

    [SerializeField] Text hintText;
    [SerializeField] Text hintTextN;
    [SerializeField] GameObject backGroundForHint; 
    
    public void presed()
    {
        backGroundForHint.SetActive(true);

        //進行度に応じて書く
        int progress = NB.next + STAT.instance.N;
        for (int i = 0; i < progress; i++)
        {
            if (i > 9) { break; }
            hintTextN.text += i+1 + "." + "\n";
            hintText.text += NB.hints[i];
            if (i == NB.next)
            {
                hintText.text += "  (next)";
            }
            hintText.text += "\n";
        }
    }
    
    public void UnPressed()
    {
        backGroundForHint.SetActive(false);
        hintText.text = "";
        hintTextN.text = "";
    }
}