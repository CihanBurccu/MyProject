using Dreamteck.Splines;
using UnityEngine;

[System.Serializable]
public enum GameState
{
    Ready,
    InGame
}

public class PlayerMovement : MonoBehaviour
{
    public GameState gameState = GameState.Ready;

    private Vector3 playerScale, playerMaxScale, playerMinScale;
    public SwipeManager swipeManager;
    private SplineFollower mySplineFollower;
    private float scaleRatio = 1.5f;
    private float moveLeftRightSpeed = 20f;


    void Start()
    {
        playerScale = new Vector3(0.75f, 0.75f, 0f);
        playerMaxScale = new Vector3(1.5f, 1.5f, 1f);
        playerMinScale = new Vector3(0.5f, 0.5f, 1f);
        mySplineFollower = GetComponentInParent<SplineFollower>();
    }

    void Update()
    {
        switch (gameState)
        {
            case GameState.Ready:
                if (swipeManager.tap)
                {
                    ReadyState();
                    gameState = GameState.InGame;
                }
                break;
            case GameState.InGame:
                InGameState();
                break;
        }
    }


    void IncreasePlayer()
    {
        if (gameObject.transform.localScale.x <= playerMaxScale.x)
        {
            gameObject.transform.localScale += playerScale * Time.deltaTime * scaleRatio;
        }
    }

    void DecrasePlayer()
    {
        if (gameObject.transform.localScale.x >= playerMinScale.x)
        {
            gameObject.transform.localScale -= playerScale * Time.deltaTime * scaleRatio;
        }
    }

    void MoveRigthAndMoveLeft()
    {
        if (mySplineFollower.motion.offset.x + swipeManager.difference.x < 5f && mySplineFollower.motion.offset.x + swipeManager.difference.x > -5f)
        {
            mySplineFollower.motion.offset = Vector2.Lerp(new Vector2(mySplineFollower.motion.offset.x, 0), new Vector2(swipeManager.difference.x + mySplineFollower.motion.offset.x, 0), moveLeftRightSpeed * Time.deltaTime);
        }
    }

    void ReadyState()
    {
            LevelManager.instance.CameraMoveStart();
            mySplineFollower.followSpeed = 20;
    }

    void InGameState()
    {
        if (swipeManager.tap)
            IncreasePlayer();

        if (swipeManager.tapUp)
            DecrasePlayer();

        if (swipeManager.swipeLeft)
            MoveRigthAndMoveLeft();

        if (swipeManager.swipeRight)
            MoveRigthAndMoveLeft();
    }
}