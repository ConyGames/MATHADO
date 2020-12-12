using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
class ProbelmStatements {

    [Tooltip("Maximum Number Range for problem statements")]
    [Range(0, 100)] public int MinRange = 0;

    [Tooltip("Maximum Number Range for problem statements")]
    [Range(0, 100)] public int MaxRange = 0;

    
};

public class ProblemGen : MonoBehaviour
{
    [SerializeField] private List<ProbelmStatements> problemStatements = new List<ProbelmStatements>();

    [SerializeField] private List<GameObject> Grounds = new List<GameObject>();

    private System.Random r = new System.Random();
    [SerializeField] private Text problemStateMentText = null;

    [Tooltip("Tick it if the this is the starting block of the game")]
    public bool StartingBlock;

    void Start()
    {
        problemStateMentText = GameObject.FindGameObjectWithTag("ProblemStatement").GetComponent<Text>();
        Destroy(gameObject.GetComponent<MeshRenderer>());
        Destroy(gameObject.GetComponent<MeshFilter>());
    }

    public void SetProblemStatement(){
        if (StartingBlock){
            problemStateMentText.text = "Start";
            Grounds[0].GetComponent<AnswerCheck>().IsRight = true;
        } 
        else{
            problemStateMentText.text = GetProblemStatement();
        }
    }

    public void DoDestroy(){
        if (Grounds.Count > 0) foreach(var _objects in Grounds)    Destroy(_objects);
        Destroy(gameObject);
    }

    private String GetProblemStatement(){
        String temp = "";
        int sum = 0;
        foreach(var statements in problemStatements){
            int random = r.Next(statements.MinRange, statements.MaxRange);
            sum += random;
            temp += random.ToString();
            temp += "+";
        }

        foreach(var _object in Grounds){
            int num = r.Next(0, sum-1);
            while(num == sum) num = r.Next(0, sum-1);
            _object.GetComponent<AnswerCheck>().SetAnswer(num.ToString());
        }
        var CorrectObject = Grounds[r.Next(0, Grounds.Count)].GetComponent<AnswerCheck>();
        CorrectObject.IsRight = true;
        CorrectObject.SetAnswer(sum.ToString());

        temp = temp.Remove(temp.Length - 1, 1);
        return temp;
    }
};
