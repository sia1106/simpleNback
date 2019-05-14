using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour {
    
    [SerializeField]Text lv;
    
    //Nの方はUpdateに書くのを避けてスライダーの方で
	void Start () {
        lv.text = STAT.instance.N.ToString() + "-Back";
    }    
}
