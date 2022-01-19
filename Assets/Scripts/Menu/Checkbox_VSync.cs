using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkbox_VSync : CheckboxBase
{

    void Start()
    {
        base.Start();

        SetToggle(QualitySettings.vSyncCount > 0);
    }
    public override void Toggle()
    {
        if (isToggled) QualitySettings.vSyncCount = 1;
        else QualitySettings.vSyncCount = 0;
    }

}
