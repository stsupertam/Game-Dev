using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserNameController : MonoBehaviour {

    public string stringToEdit = "Your name";
    public static string username;

    void OnGUI() {
        stringToEdit = GUI.TextField(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 10, 100, 20), stringToEdit, 12);
        username = stringToEdit;
    }
}
