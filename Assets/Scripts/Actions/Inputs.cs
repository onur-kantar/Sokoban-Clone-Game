using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inputs : MonoBehaviour
{
    protected Movement movement;
    private void Awake()
    {
        movement = GetComponent<Movement>();
    }
}
