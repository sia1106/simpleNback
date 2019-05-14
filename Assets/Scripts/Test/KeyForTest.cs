using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyForTest : MonoBehaviour {

    //テスト用
    NumberManager NB;
    
    void Start () {

        NB = GameObject.Find("NumberManager").GetComponent<NumberManager>();

    }
	
	void Update () {
        if (Input.anyKeyDown)
        {
            for(int i = 0; i < 10; i++)
            {
                int temp = i;
                if (Input.GetKey(temp.ToString()))
                {
                    NB.inputNumber = temp;
                }
            }
        }
	}
}
