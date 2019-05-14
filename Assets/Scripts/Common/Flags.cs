using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flags : MonoBehaviour {

    static public Flags instance;

    public bool isPlayStart;
    public bool isPlayEnd;
    
    void Start() {

        if (instance == null)
        {
            instance = this;
        }

        isPlayStart =false;
        isPlayEnd = false;
    }	
}
