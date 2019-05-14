using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestSlider : MonoBehaviour {

    [SerializeField] Slider restSlider;
    [SerializeField] Text resttex;
    [SerializeField]NumberManager NB;
    
	void Update() {
        restSlider.value = NB.rest;
        resttex.text = restSlider.value + "/10";
    }
}