using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OKbutton : MonoBehaviour {

    [SerializeField]NumberManager NB;
    
	public void OKClick()
    {
            NB.OKButton = true;
    }
}
