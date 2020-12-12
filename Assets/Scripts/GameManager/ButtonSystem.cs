using UnityEngine;

public class ButtonSystem : MonoBehaviour
{
    [SerializeField] private GameObject LocalPlayer = null;
    private MovementLocalPlayer movementLocalPlayer = null;

    private void Start(){
        movementLocalPlayer = LocalPlayer.GetComponent<MovementLocalPlayer>();
    }

    public void JumpButton(){
        movementLocalPlayer.Jump();
    }

    public void MoveLeft(){
        movementLocalPlayer.MoveLeft();
    }

    public void MoveRight(){
        movementLocalPlayer.MoveRight();
    }
}
