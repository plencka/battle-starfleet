using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkbox_Fullscreen : ButtonBase
{
    bool isToggled;
    public GameObject checkboxImage;
    void Start()
    {
        base.Start();

        isToggled = PlayerPrefs.GetInt("isFullscreenOn") == 1;
        if (isToggled) checkboxImage.SetActive(true);  
    }

    public override void Click()
    {
        if (isToggled)
        {
            checkboxImage.SetActive(false);
        }
        else
        {
            checkboxImage.SetActive(true);
        }

        isToggled = !isToggled;
        Screen.fullScreen = isToggled;

    }


}
