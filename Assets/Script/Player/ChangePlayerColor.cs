using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerColor : MonoBehaviour
{

    public Material materialToChange;
    Color purpleColor = new Color32 (131 , 64 , 255, 255);
    Color greenColor = new Color32 (193 , 255 , 6 , 255);
    Color yellowColor = new Color32 (250 , 167 , 1, 255);
    Color redColor = new Color32 (252, 63, 105, 255);
    private float duration = 1.5f;
    

    public void ChangeColorRed()
    {
        StartCoroutine(ChangeColor(redColor));
    }

    public void ChangeColorGreen()
    {
        StartCoroutine(ChangeColor(greenColor));
    }

    public void ChangeColorYellow()
    {
        StartCoroutine(ChangeColor(yellowColor));
    }

    public void ChangeColorPurple()
    {
        StartCoroutine(ChangeColor(purpleColor));
    }


    IEnumerator ChangeColor(Color color)
    {
        float time = 0;
        Color startValue = materialToChange.color;

        while (time < duration)
        {
            materialToChange.color = Color.Lerp(startValue, color, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        materialToChange.color = color;
    }
}
