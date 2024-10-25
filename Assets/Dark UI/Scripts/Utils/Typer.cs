using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Typer : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float timeBetweenLetters;

    public string phrase;

    private void Awake()
    {
        Erase();
    }


    [NaughtyAttributes.Button]
    public void StartType()
    {
        StartCoroutine(Type(phrase));
    }

    public void Erase()
    {
        textMesh.text = "";
    }


    IEnumerator Type(string s)
    {
        textMesh.text = "";
        foreach(char l in s.ToCharArray())
        {
            textMesh.text += l;
            yield return new WaitForSeconds(timeBetweenLetters);
        }
    }


}
