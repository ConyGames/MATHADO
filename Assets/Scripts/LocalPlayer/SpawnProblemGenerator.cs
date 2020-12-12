using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProblemGenerator : MonoBehaviour
{
    // this file will generate ProblemGenerator Objects
    [Tooltip("Generate as many prefabs you want in runtime index will be randome")]
    [SerializeField] private List<GameObject> ProblemGenerator = new List<GameObject>();
    [SerializeField] private Vector3 SpawnOffset = new Vector3();
    private System.Random r = new System.Random();
    private GameObject problemGenaratorRef;
    public void Genarate(){
        int index = r.Next(0, ProblemGenerator.Count-1);

        // instantiating ProblemGenerator Objects
        problemGenaratorRef = Instantiate(ProblemGenerator[index], gameObject.transform.position+SpawnOffset, gameObject.transform.rotation);
    }

    void Start()
    {
        problemGenaratorRef = new GameObject();
    }
    void Update()
    {
        if (!problemGenaratorRef) // mean We Do not have Anyother Problem Generator in the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
