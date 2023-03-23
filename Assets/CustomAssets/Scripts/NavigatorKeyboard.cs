using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigatorKeyboard : Navigation
{
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        MovementAxis = new Vector2(horizontal,vertical);

        run = Input.GetKey(KeyCode.LeftShift);
        jump = Input.GetKey(KeyCode.Space);
    }
}
