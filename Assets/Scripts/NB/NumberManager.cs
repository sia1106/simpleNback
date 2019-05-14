using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberManager : MonoBehaviour
{
    public int inputNumber;
    private PushPanel[] panel=new PushPanel[10];

    public int[,] array2D = new int[2, 10];
    public int[] answers = new int[10];
    public string[] hints = new string[10];

    public int rest;//残り
    public int next;//次
    private int j;//ただのカウンタ
    private int n; //instanceから受け取る

    public Text question;//数式表示
    [SerializeField] GameObject NP;//ナンバーパネルの親、表示非表示

    [SerializeField] GameObject OKB;//OKボタン
    public bool OKButton;//OKボタンの入力待ちに使う

    [SerializeField] GameObject STB;//STOPボタン
    [SerializeField] GameObject HintB;//Hintボタン

    [SerializeField] Result result;
    [SerializeField] SOUND sound;

    void Start()
    {
        sound.playBGM();

        Flags.instance.isPlayStart = false;
        Flags.instance.isPlayEnd = false;

        n = STAT.instance.N;

        //式と答えを配列へ
        for (int i = 0; i < 10; i++)
        {
            //1～9までの数字
            int temp1 = Random.Range(1, 10);
            int temp2 = Random.Range(1, temp1);
            answers[i] = temp1;
            array2D[0, i] = temp2;
            array2D[1, i] = temp1 - temp2;
            
            hints[i] = array2D[0, i] + " + " + array2D[1, i] + " = " + answers[i];
        }
        
        //数字ごとのパネルオブジェクトを取得
        for (int i = 1; i < 10; i++)
        {
            string temp = i.ToString();
            panel[i]= GameObject.Find(temp).GetComponent<PushPanel>();
        }

        //初期化
        NP.SetActive(false);
        STB.SetActive(false);
        j = 0;
        next = 0;
        rest = 10;
        inputNumber = 11;

        StartCoroutine(RememberTime());
    }

    //再開時
    public void Again()
    {
        StartCoroutine(PlayTime());
    }

    IEnumerator RememberTime()
    {   
        //ｎ回繰り返す、添え字を増やす
        for (int i = 0; i < n; i++)
        {
            question.text = array2D[0, j].ToString() + "+" + array2D[1, j].ToString() + "=";
            j++;
            //入力を待つ
            yield return StartCoroutine(WaitForInput());
        }

        Destroy(OKB);
        yield return StartCoroutine(PlayTime());
    }

    //入力待ち
    IEnumerator WaitForInput()
    {
        while (OKButton == false)
        {
            yield return new WaitForSeconds(0.1f);
        }
        OKButton = false;
    }

    IEnumerator PlayTime()
    {
        NP.SetActive(true);
        STB.SetActive(true);

        while (Flags.instance.isPlayEnd == false)
        {
            next = j - n;

            Flags.instance.isPlayStart = true;

            //配列の添え字は0～9
            if (j < 10)
            {
                question.text = array2D[0, j].ToString() + "+" + array2D[1, j].ToString() + "=";
            }
            else
            {
                question.text = "";
            }

            //入力判定
            if (inputNumber <= 10)
            {
                //N個前の答えとマッチ
                if (inputNumber == answers[j - n])
                {
                    //正解
                    panel[inputNumber].EffectSign(0);
                    sound.GoodSE();
                    inputNumber = 11;
                    j++;
                    rest--;
                }
                else
                {
                    //不正解
                    panel[inputNumber].EffectSign(1);
                    sound.BadSE();
                    inputNumber = 11;
                }
                //残りゼロ→終了
                if (rest <= 0)
                {
                    sound.ClearSE();
                    question.text = "Finish";
                    Flags.instance.isPlayEnd = true;
                    Flags.instance.isPlayStart = false;
                    //0＝通常終了フラグを渡して終わり
                    STB.SetActive(false);
                    HintB.SetActive(false);
                    result.ResultStart(0);

                    yield break;
                }
                yield return null;
            }
            yield return null;
        }
        yield return null;
    }

}