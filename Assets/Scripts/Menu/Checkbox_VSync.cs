using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkbox_VSync : CheckboxBase
{

    void Start()
    {
        base.Start();

        isToggled = PlayerPrefs.GetInt("isVSyncOn") == 1;
        if (isToggled) checkboxImage.SetActive(true);
    }
    public override void Click()
    {
        Toggle();

        if (isToggled) QualitySettings.vSyncCount = 1;
        else QualitySettings.vSyncCount = 0;
    }

}
