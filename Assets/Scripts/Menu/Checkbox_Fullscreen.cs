using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkbox_Fullscreen : CheckboxBase
{
    void Start()
    {
        base.Start();

        isToggled = PlayerPrefs.GetInt("isFullscreenOn") == 1;
        if (isToggled) checkboxImage.SetActive(true);  
    }

    public override void Click()
    {
        Toggle();

        Screen.fullScreen = isToggled;
    }


}
