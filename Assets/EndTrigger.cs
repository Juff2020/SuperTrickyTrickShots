using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        gameManager.ballStillInHoop = true;
        gameManager.ballInHoopTimerStart();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        gameManager.ballStillInHoop = false;
        gameManager.ballInHoopTimerStop();
    }

}
