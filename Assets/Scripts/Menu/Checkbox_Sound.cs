using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkbox_Sound : CheckboxBase
{

    void Start()
    {
        base.Start();

        isToggled = PlayerPrefs.GetInt("isSoundOn") == 1;
        if (isToggled) checkboxImage.SetActive(true);
    }
    public override void Click()
    {
        base.Click();

        if (isToggled) AudioListener.volume = 1f;
        else AudioListener.volume = 0f;
    }


}
