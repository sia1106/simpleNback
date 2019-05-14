using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour {

    [SerializeField] NumberManager NB;
    private PushPanel[] numberPanels;
    
    void Start ()
    {
        numberPanels = new PushPanel[10];
        for (int i = 1; i < 10; i++)
        {
            string temp = i.ToString();
            numberPanels[i] = GameObject.Find(temp).GetComponent<PushPanel>();
        }
    }
    
    public void HintPress()
    {
        StartCoroutine("Enlighten");
    }

    public void HintUnpress()
    {
        StopCoroutine("Enlighten");
    }

    IEnumerator Enlighten()
    {
        while (true)
        {
                int nextbutton = NB.answers[NB.next];
                StartCoroutine(numberPanels[nextbutton].Flashing());
                yield return new WaitForSeconds(0.25f);
        }
    }
}
