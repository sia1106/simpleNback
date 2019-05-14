using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour {
    
    //prefabsにつけて生成されたらポップアップして消えるだけ

	void Start () {
        StartCoroutine(des());
        StartCoroutine(moving());
    }	

    IEnumerator moving()
    {
        while (true)
        {
            transform.Translate(0,0.8f, 0);
            float t = Time.deltaTime/10;
            yield return new WaitForSeconds(t);
        }
    }

    IEnumerator des()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(this.gameObject);
    }
}