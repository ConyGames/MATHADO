using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalPlayerCollisionSystem : MonoBehaviour
{
    private MovementLocalPlayer movementLocalPlayer;
    private SpawnProblemGenerator spawnProblemGenerator;

    private void Start()
    {
        movementLocalPlayer = gameObject.GetComponent<MovementLocalPlayer>();
        spawnProblemGenerator = gameObject.GetComponent<SpawnProblemGenerator>();
    }

    void OnCollisionEnter(Collision other)
    {
        switch(other.collider.tag){
            case "Ground":
                if (!other.gameObject.GetComponent<AnswerCheck>().IsRight) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                movementLocalPlayer.CanJump(true);
                spawnProblemGenerator.Genarate();
                break;
            default :
                break;
        }
    }


    void OnCollisionExit(Collision other)
    {
        switch(other.collider.tag){
            case "Ground":
                movementLocalPlayer.CanJump(false);
                break;
            default :
                break;
        }
    }
}
