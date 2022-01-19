using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    public bool tap, tapUp, swipeLeft, swipeRight;
    public Vector2 swipeDelta, swipeDeltaTemp, startTouch;
    public Vector3 difference;
    private Touch touch;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                tapUp = false;
                tap = true;
                startTouch = touch.position;
            }
            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                tapUp = true;
                tap = false;
            }
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                swipeDeltaTemp = touch.position;
                swipeDelta = swipeDeltaTemp - startTouch;
                difference = swipeDelta / Screen.width;
            }

            if (swipeDelta.magnitude > 100)
            {
                float x = swipeDelta.x;

                if (x < 0)
                {
                    swipeLeft = true;
                    swipeRight = false;
                }
                else
                {
                    swipeRight = true;
                    swipeLeft = false;
                }
            }
        }
        else
        {
            tap = swipeLeft = swipeRight = false;
            tapUp = true;
        }
    }
}