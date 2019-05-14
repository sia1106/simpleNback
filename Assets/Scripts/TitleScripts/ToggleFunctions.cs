using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleFunctions : MonoBehaviour {

    [SerializeField] Toggle BGMtog;
    [SerializeField] Toggle SEtog;

    private void Start()
    {
        //初期化
        BGMtog.isOn = STAT.instance.BGMFlag;
        SEtog.isOn = STAT.instance.SEFlag;
        BGMtog.onValueChanged.AddListener(delegate { BGMswitch(); });
        SEtog.onValueChanged.AddListener(delegate { SEswitch(); });
    }

    public void BGMswitch()
    {
        STAT.instance.BGMFlag = !STAT.instance.BGMFlag;
        //prefs用にint型にする
        int bgmflag = STAT.instance.BGMFlag ? 1 : 0;
        PlayerPrefs.SetInt("BGMFlag", bgmflag);
    }

    public void SEswitch()
    {
        STAT.instance.SEFlag = !STAT.instance.SEFlag;

        int seflag = STAT.instance.SEFlag ? 1 : 0;
        PlayerPrefs.SetInt("SEFlag", seflag);
    }
}
