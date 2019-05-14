using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float timeCount;
    Text timeUI;
    Result result;

    void Start () {
        timeUI = GetComponent<Text>();
        result = GameObject.Find("Result").GetComponent<Result>();
    }
	
	void FixedUpdate () {
        if (Flags.instance.isPlayStart == true&& Flags.instance.isPlayEnd == false)
        {
            timeCount += Time.deltaTime;
            timeUI.text = "Time: " + timeCount.ToString("F1");

            //最長５分
            if (timeCount > 300)
            {
                timeUI.text = "TIME UP";
                Flags.instance.isPlayEnd=true;
                //引数：１はタイムアップで終了処理
                result.ResultStart(1);
            }
                        
        }
        
	}
    
    
}
