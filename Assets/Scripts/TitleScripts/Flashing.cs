using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashing : MonoBehaviour {

    private Graphic graphic;
    private Color defcolor;
    float time;
    [SerializeField] float angularFrequency = 1.5f;
    [SerializeField] float delta = 0.01f;

    void Start () {
        graphic = GetComponent<Graphic>();
        defcolor =graphic.color;
        time = 0.0f;
        StartCoroutine(Lighting());
	}

    IEnumerator Lighting()
    {
        Color color = graphic.color;
        while (true)
        {
            time += delta*angularFrequency;
            float alpha = Mathf.Sin(time)*0.5f+0.2f;
            color.a = alpha;
            graphic.color = color;
            yield return new WaitForSeconds(0.01f);
        }        
    }	
}