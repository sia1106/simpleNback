using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credit : MonoBehaviour {

    [SerializeField] GameObject back;

    public void CreditON()
    {
        back.SetActive(true);
    }

    public void CreditOFF()
    {
        back.SetActive(false);
    }        

}
