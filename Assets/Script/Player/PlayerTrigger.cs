using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Obstacle"))
            LevelManager.instance.FailState();
    }

    public void Success()
    {
        LevelManager.instance.SuccesState();
    }

}
