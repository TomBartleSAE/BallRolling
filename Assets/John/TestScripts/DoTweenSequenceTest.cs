using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenSequenceTest : MonoBehaviour
{
    public float startingValue;
    //public float target = 5f;
    //public float secondTarget;
    //public float thirdTarget = -5f;

    public float duration;

    public List<float> targetList = new List<float>();

    float currentTarget = 0f;

    //Sequence mySequence = DOTween.Sequence();

    // Start is called before the first frame update
    void Start()
    {
        Sequence mySequence = DOTween.Sequence();


        //EXAMPLE SEQUECE CODE
        /* 
        mySequence.Append(transform.DOMoveX(45, 10));
        // Add a rotation tween as soon as the previous one is finished
        mySequence.Append(transform.DORotate(new Vector3(0, 180, 0), 1));
        // Delay the whole Sequence by 1 second
        mySequence.PrependInterval(1);
        // Insert a scale tween for the whole duration of the Sequence
        mySequence.Insert(0, transform.DOScale(new Vector3(3, 3, 3), mySequence.Duration()));
        */


        //ORIGINAL SOLUTION
        /*
        //Move Object to the right
        mySequence.Append(DOTween.To(Getter, SetMovement, target, duration));
                //Wait 2 Seconds
                //mySequence.PrependInterval(2);
        //Move Object Back to Start Pos
        mySequence.Append(DOTween.To(Getter, SetSecondMovement, secondTarget, duration));
                //Wait Another 2 Seconds
                //mySequence.PrependInterval(2);
        //Move Object to the left
        mySequence.Append(DOTween.To(Getter, SetThirdMovement, thirdTarget, duration));
                //Wait 2 Seconds Again
                //mySequence.PrependInterval(2);
        //Move Object Back to Start Pos
        mySequence.Append(DOTween.To(Getter, SetSecondMovement, secondTarget, duration));
        */


        currentTarget = startingValue;


        //FIRST SOLUTION USING SAME SETMOVEMENT FUNCTION
        /*
        //Move Object to the right
        mySequence.Append(DOTween.To(Getter, SetMovement, target, duration));
        //Move back to start
        mySequence.Append(DOTween.To(Getter, SetMovement, secondTarget, duration));
        //Move Object to the left
        mySequence.Append(DOTween.To(Getter, SetMovement, thirdTarget, duration));
        //Move Object back to start
        mySequence.Append(DOTween.To(Getter, SetMovement, secondTarget, duration));
        */


        //ALTERNATIVE SOLUTIONS - MOST OPTIMIZED SOLUTIONS

        //FOR LOOP
        /*
        for(int i = 0; i<targetList.Count; i++)
        {
            mySequence.Append(DOTween.To(Getter, SetMovement, targetList[i], duration));
        }
        */


        //FOREACH LOOP
        foreach(float target in targetList)
        {
            mySequence.Append(DOTween.To(Getter, SetMovement, target, duration));
        }
    }

    //Get the current / starting value
    float Getter()
    {
        //return startingValue;

        return currentTarget;
    }

    //Set a new target to move towards
    void SetMovement(float newTarget)
    {
        //startingValue = newTarget;

        currentTarget = newTarget;

        //Move Object X Pos
        transform.localPosition = new Vector3(newTarget, 1, 1);
    }


    //COPY PASTED FUNCTIONS FOR OLD SOLUTION
    /*
    void SetSecondMovement(float newSecondTarget)
    {
        startingValue = newSecondTarget;

        //Move Object X Pos
        transform.localPosition = new Vector3(newSecondTarget, 1, 1);
    }

    void SetThirdMovement(float newThirdTarget)
    {
        startingValue = newThirdTarget;

        //Move Object X Pos
        transform.localPosition = new Vector3(newThirdTarget, 1, 1);
    }
    */


}
