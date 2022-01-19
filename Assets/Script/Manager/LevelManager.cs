using DG.Tweening;
using Dreamteck.Splines;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public SplineFollower mySplineFollower;

    public PlayerMovement playerMovement;

    public Transform[] cameraTargets;
    public GameObject myCamera;
    public GameObject vfx;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        vfx.gameObject.SetActive(false);
        mySplineFollower.followSpeed = 0f;
        myCamera.transform.position = cameraTargets[0].transform.position; 
        myCamera.transform.rotation = cameraTargets[0].transform.rotation;
    }

    public void CameraMoveStart()
    {
        myCamera.transform.DOLocalMove(cameraTargets[1].transform.position, 1);
        myCamera.transform.DOLocalRotate(cameraTargets[1].transform.eulerAngles, 1);
    }

    public void CameraMoveFinish()
    {
        myCamera.transform.DOMove(cameraTargets[2].transform.position, 2);
        myCamera.transform.DORotate(cameraTargets[2].transform.eulerAngles, 2);
    }
    
    public void SuccesState()
    {
        vfx.gameObject.SetActive(true);
        mySplineFollower.followSpeed = 0f;
        CameraMoveFinish();
        playerMovement.enabled = false;
        GameManager.instance.SetSuccessMenuState(true);
        
    }

    public void FailState()
    {
        mySplineFollower.followSpeed = 0f;
        playerMovement.enabled = false;
        GameManager.instance.SetFailMenuState(true);
    }
}
