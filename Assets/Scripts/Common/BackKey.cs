using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackKey : MonoBehaviour {

    //シーンインデックスを取得してシーンに対応した処理
    private int SceneNumber;

    private void Start()
    {        
        //0：タイトル
        //1：プレイ
        //2：セッティング
        SceneNumber = SceneManager.GetActiveScene().buildIndex;
    }
    
    void Update () {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (SceneNumber)
            {
                case 0:
                    if (Application.platform == RuntimePlatform.Android)
                    {
                        Application.Quit();
                    }
                    break;
                case 1:
                    SceneManager.LoadScene("Title");
                    break;
                case 2:
                    SceneManager.LoadScene("Title");
                    break;
                default :
                    break;
            }
        }
    }
}