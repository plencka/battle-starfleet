using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkbox_VSync : ButtonBase
{
    bool isToggled;
    public GameObject checkboxImage;

    void Start()
    {
        base.Start();

        isToggled = PlayerPrefs.GetInt("isVSyncOn") == 1;
        if (isToggled) checkboxImage.SetActive(true);
    }
    public override void Click()
    {
        if (isToggled)
        {
            checkboxImage.SetActive(false);
            QualitySettings.vSyncCount = 0;
        }
        else
        {
            checkboxImage.SetActive(true);
            QualitySettings.vSyncCount = 1;
        }
        isToggled = !isToggled;

    }

}
