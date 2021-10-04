using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperModel : MonoBehaviour
{
    Vector3 originalPos;

    int target;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;

        StartCoroutine(MoveCube());
    }

    // Update is called once per frame
    void Update()
    {

        float lerp = Mathf.Lerp(transform.position.y, target, speed);
        transform.Rotate(new Vector3(originalPos.x, originalPos.y, lerp));

    }

    IEnumerator MoveCube()
    {
        target = 90;
        speed = 0.5f;

        yield return new WaitForSeconds(1f);

        target = 0;
        speed = 0.05f;

        yield return new WaitForSeconds(3f);

        StartCoroutine(MoveCube());
    }
}
