using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupStartMenu : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    [SerializeField] private Text playerName;
    public void OnClickJoin()
    {
        if (!(2 < inputField.text.Length && inputField.text.Length < 10))
        {
            return;
        }

        playerName.text = inputField.text;

        Destroy(gameObject);
    }
}
