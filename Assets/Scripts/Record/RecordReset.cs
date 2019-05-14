using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordReset : MonoBehaviour {

    [SerializeField] GameObject Background;

    public void RecordResetButton()
    {
        Background.SetActive(true);
    }

    public void ResetOK()
    {
        for (int i = 0; i < 11; i++)
        {
            string temp = "N=" + i.ToString();
            PlayerPrefs.DeleteKey(temp);
        }

        STAT.instance.DateReflesh();
        Background.SetActive(false);
    }

    public void ResetCancel()
    {
        Background.SetActive(false);
    }
}