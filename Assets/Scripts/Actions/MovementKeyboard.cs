using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementKeyboard : Movement
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SetDirection(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            SetDirection(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            SetDirection(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            SetDirection(Vector2.right);
        }
    }
}
