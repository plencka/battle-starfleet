using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkbox_Fullscreen : CheckboxBase
{
    void Start()
    {
        base.Start();
        SetToggle(Screen.fullScreen);
    }

    public override void Toggle()
    {
        Screen.fullScreen = isToggled;
    }
}
