using UnityEditor;
using UnityEngine;

public class PlayerPrefsEditor
{
    //エディター用、prefsをリセット
    [MenuItem("Tools/PlayerPrefs/DeleteAll")]
    static void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Delete All Data Of PlayerPrefs!!");
    }
}