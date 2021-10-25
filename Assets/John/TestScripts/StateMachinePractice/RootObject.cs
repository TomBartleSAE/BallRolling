using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootObject : MonoBehaviour
{
    StateManager sm;

    public StateBase secondState;
    public StateBase firstState;

    // Start is called before the first frame update
    void Awake()
    {
        sm = GetComponent<StateManager>();
    }



}
