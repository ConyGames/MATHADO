using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ProblemGenCollisionSystem : MonoBehaviour
{
    private ProblemGen problemGen;


    void Start()
    {
        problemGen = gameObject.GetComponent<ProblemGen>();
    }
    void OnTriggerEnter(Collider other)
    {
        switch(other.tag){
            case "LocalPlayer" :
                problemGen.SetProblemStatement();
                break;
            default:
                break;
        }
    }


    void OnTriggerExit(Collider other)
    {
        switch(other.tag){
            case "LocalPlayer" :
                CheckForGameOver();
                problemGen.DoDestroy();
                break;
            default:
                break;
        }
    }

    private void CheckForGameOver(){
        GameObject[] temp = GameObject.FindGameObjectsWithTag("ProblemStatement");

        if ( temp.Count() == 0 )  // Mean No Objects are there
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
