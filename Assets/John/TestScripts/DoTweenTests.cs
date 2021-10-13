using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenTests : MonoBehaviour
{
    public float zoomLevel = 5f;
    public float target = 10f;


    public float duration = 2f;

    // Start is called before the first frame update
    void Start()
    {
            //MINIMAL EXAMPLE (A)
        //DOTween.To(JustASetter, 5, 1, duration);


            //MINIMAL EXAMPLE WITH GETTER & VARIABLES (B) - target variable sets the new zoomLevel using the Setter function
            //Getter is getting the current value, Setter is setting the new value which is given by the target variable
        //DOTween.To(Getter, Setter, target, duration);


            //ADVANCED EXAMPLE - SETTING UP MULTIPLE OPTIONS
        DOTween.To(Getter, Setter, target, duration).SetEase(Ease.OutBounce).OnComplete(Finish);
    }

    /* (A)
    void JustASetter(float newValue)
    {
        transform.localScale = new Vector3(newValue, newValue, 1);
    }
    */

    //SET NEW TARGET
    void Setter(float newZoomLevel)
    {
        zoomLevel = newZoomLevel;

        //EXAMPLE (C) GIVING THE SETTER A SPECIFIC TASK
        transform.localScale = new Vector3(zoomLevel, zoomLevel, 1);
    }

    //GET THE STARTING POS/VALUE
    float Getter()
    {
        return zoomLevel;
    }

    void Finish()
    {
        Debug.Log("Tween Finished!!");
    }







}
