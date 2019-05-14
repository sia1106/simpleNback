using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderN : MonoBehaviour {
 
    [SerializeField] Slider NSlider;
    [SerializeField] Text lv;

    public void Start()
    {
        NSlider.value = STAT.instance.N;
        NSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });        
    }
    
    public void ValueChangeCheck()
    {
        int n = Mathf.FloorToInt(NSlider.value);
        lv.text = n.ToString() + "-Back";
        STAT.instance.N = n;
        //セーブ
        PlayerPrefs.SetInt("N", STAT.instance.N);
    }
    
}
