using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    [Header("Control Points")]
    public Transform p0;
    public Transform p1;
    public Transform p2;
    public Transform p3;

    [Space]
    //public float time;

    [Range(0f,1f)]
    public float t;

    [Space]
    public Vector2 point;

    [Space]
    [Header("Presets")]
    public bool automatic = false;
    public bool reset = false;
    public bool pingpong = false;

    // Update is called once per frame
    void Update()
    {
        //if(!pingpong)
        
        CheckPresets();
        
        if(pingpong)
        {
            StartCoroutine(PingPong());
        }

        Vector2 a = Vector2.Lerp(p0.position, p1.position, t);
        Vector2 b = Vector2.Lerp(p1.position, p2.position, t);
        Vector2 c = Vector2.Lerp(p2.position, p3.position, t);
        Vector2 d = Vector2.Lerp(a, b, t);
        Vector2 e = Vector2.Lerp(b, c, t);
        point = Vector3.Lerp(d, e, t);
    }

    
    void OnDrawGizmos()
    {

        Gizmos.DrawSphere(point, 1f);
    }

    void CheckPresets()
    {
        if (automatic)
        {
            t += Time.deltaTime;

            if (t >= 1f)
            {
                automatic = false;
            }
        }

        if (reset)
        {
            t -= Time.deltaTime;

            if (t <= 0)
            {
                reset = false;
            }
        }
    }

    void Forward()
    {
        t += Time.deltaTime;
    }
    void Reverse()
    {
        t -= Time.deltaTime;
    }

    IEnumerator Automatic()
    {
        t += Time.deltaTime;

        yield return new WaitForSeconds(1.5f);

        automatic = false;
    }

    IEnumerator PingPong()
    {
        //t += Time.deltaTime;

        reset = false;
        automatic = true;

        yield return new WaitForSeconds(2f);

        //t -= Time.deltaTime;

        automatic = false;
        reset = true;

        yield return new WaitForSeconds(3f);

        //automatic = false;
        reset = false;

        StartCoroutine(PingPong());

        //yield return new WaitForSeconds(2f);

        //reset = false;
        //StartCoroutine(PingPong());
    }



    //EVENT DECLARATION

    //Finished Event
    public delegate void FinishedSignature();
    public event FinishedSignature FinishedEvent;

    public void FinishedFunction()
    {
        FinishedEvent?.Invoke();
    }

    private void OnEnable()
    {
        FinishedEvent += Reverse;
    }


}
