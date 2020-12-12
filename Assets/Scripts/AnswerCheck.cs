using System;
using UnityEngine;

public class AnswerCheck : MonoBehaviour
{
    public bool IsRight = false;
    [SerializeField] private TMPro.TMP_Text testMesh = null;

    public void SetAnswer(String text){
        testMesh.text = text;
    }
}
