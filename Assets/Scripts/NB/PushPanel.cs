using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushPanel : MonoBehaviour
{

    private NumberManager NB;
    public int pushedNumber;

    [SerializeField] GameObject effectCircle;
    [SerializeField] GameObject effectCross;

    private Graphic graphic;
    private Color defcolor;    

    public void Start()
    {
        graphic = GetComponent<Graphic>();
        defcolor = graphic.color;

        NB = GameObject.Find("NumberManager").GetComponent<NumberManager>();
        pushedNumber = int.Parse(this.gameObject.name);
    }

    //NumberManagerに送る
    public void Push()
    {
        NB.inputNumber = pushedNumber;
    }

    //ボタン押下時に生成、自動で消える
    public void EffectSign(int fl)
    {
        if (fl < 1)
        {
            Instantiate(effectCircle, this.transform);
        }
        else
        {
            Instantiate(effectCross, this.transform);
        }
    }

    public IEnumerator Flashing()
    {
        for (int i = -5; i < 5; i++)
        {
            var color = graphic.color;
            color.a = (i * i) / 25;
            graphic.color = color;
            yield return new WaitForSeconds(0.025f);
        }
        graphic.color = defcolor;
        yield return null;
    }
}