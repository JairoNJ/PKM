using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AnimationText : MonoBehaviour
{
    [SerializeField] Text myText;


    private void Start()
    {
        StartCoroutine(ShowLetterText(myText.text));
    }


    IEnumerator ShowLetterText(string text)
    {
        myText.text = "";

        foreach(var myChar in text.ToCharArray())
        {
            myText.text += myChar;
            yield return new WaitForSeconds(1f/30);
        }

    }

    public void StartGameText()
    {
        Debug.Log("Este es un texto llamado por una funcion");
    }
}
