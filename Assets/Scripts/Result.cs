using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {

    [SerializeField] GameObject NM;
    [SerializeField] Timer time;
    [SerializeField] Text result;

    [SerializeField] GameObject STB;//STOPボタン
    [SerializeField] GameObject HintB;//Hintボタン

    private void Start()
    {
        result.text = "";
    }

    public void ResultStart(int Endtype)
    {
        int n = STAT.instance.N;

        if (Endtype < 1)//通常終了
        {
            NM.SetActive(false);
            result.text = "Result\n";
            result.text += " " + n + "-Back\n";
            result.text +=" Time: " + time.timeCount.ToString("F1");
            float passedRecord =  STAT.instance.bestTime[n];
            if (passedRecord > time.timeCount)
            {
                result.text += "\n New Record!";
                STAT.instance.bestTime[n] = Mathf.Floor(time.timeCount*10)/10;
                string temp = "N=" + n.ToString();
                //記録をセーブ
                PlayerPrefs.SetFloat(temp, STAT.instance.bestTime[n]);
            }

        }

        if (Endtype > 0)//TimeUP
        {
            STB.SetActive(false);
            HintB.SetActive(false);
            NM.SetActive(false);
            result.text = "TIME UP...";
        }

    }
}
