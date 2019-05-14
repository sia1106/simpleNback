using UnityEngine;

public class STAT : MonoBehaviour
{

    //シーン間で共有し、prefsで読み書きするデータ
    static public STAT instance;
    public int N;

    public bool BGMFlag;
    public bool SEFlag;

    public float[] bestTime;

    void Awake()
    {

        N = PlayerPrefs.GetInt("N", 0);
        int bgmflag = PlayerPrefs.GetInt("BGMFlag", 0);
        int seflag = PlayerPrefs.GetInt("SEFlag", 0);
        BGMFlag = bgmflag == 1 ? true : false;
        SEFlag = seflag == 1 ? true : false;

        bestTime = new float[11];
        for (int i = 0; i < 11; i++)
        {
            string temp = "N=" + i.ToString();
            bestTime[i] = PlayerPrefs.GetFloat(temp, 300.0f);
        }

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 削除時の処理
    void OnDestroy()
    {
        int bgmflag = BGMFlag ? 1 : 0;
        int seflag = SEFlag ? 1 : 0;

        for (int i = 0; i < 11; i++)
        {
            string temp = "N=" + i.ToString();
            PlayerPrefs.SetFloat(temp, bestTime[i]);
        }

        PlayerPrefs.SetInt("BGMFlag", bgmflag);
        PlayerPrefs.SetInt("SEFlag", seflag);
        PlayerPrefs.SetInt("N", N);
        PlayerPrefs.Save();
    }

    public void DateReflesh()
    {
        N = PlayerPrefs.GetInt("N", 0);
        int bgmflag = PlayerPrefs.GetInt("BGMFlag", 0);
        int seflag = PlayerPrefs.GetInt("SEFlag", 0);
        BGMFlag = bgmflag == 1 ? true : false;
        SEFlag = seflag == 1 ? true : false;

        bestTime = new float[11];
        for (int i = 0; i < 11; i++)
        {
            string temp = "N=" + i.ToString();
            bestTime[i] = PlayerPrefs.GetFloat(temp, 300.0f);
        }

    }
}