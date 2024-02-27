using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupStartMenu : MonoBehaviour
{
    [SerializeField] private Image characterSprite;
    [SerializeField] private InputField inputField;
    [SerializeField] private GameObject information;
    [SerializeField] private GameObject selectCharacter;

    private CharacterType characterType;

    public void OnClickCharacter()
    {
        information.SetActive(false);
        selectCharacter.SetActive(true);
    }

    public void OnClickSelectCharacter(int index)
    {
        characterType = (CharacterType)index;                   //요조건에 해당하는 애를 반환
        var character = GameManager.Instance.CharacterList.Find(item => item.CharacterType == characterType);
        characterSprite.sprite = character.CharacterSprite;
        characterSprite.SetNativeSize();

        selectCharacter.SetActive(false);
        information.SetActive(true);
    }

    public void OnClickJoin()
    {
        if (!(2 < inputField.text.Length && inputField.text.Length < 10))
        {
            return;
        }

        GameManager.Instance.SetCharacter(characterType, inputField.text);

        Time.timeScale = 1;

        Destroy(gameObject);
    }
}
