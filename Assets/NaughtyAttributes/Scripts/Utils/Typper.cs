using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Typper : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float timeBetweenChars = 0.01f;
    [TextArea]
    public string phrase;

    private void Awake()
    {
        if (textMesh != null) textMesh.text = "";

    }

    IEnumerator Type(string text)
    {
        if (textMesh != null) textMesh.text = "";

        foreach (char i in text.ToCharArray()){
            textMesh.text += i;
            yield return new WaitForSeconds(timeBetweenChars);
        }
    }

    [NaughtyAttributes.Button]
    public void StartType()
    {
        StartCoroutine(Type(phrase));
    }
}
