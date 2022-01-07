using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkbox_Sound : ButtonBase
{
    bool isToggled;
    public GameObject checkboxImage;

    void Start()
    {
        base.Start();

        isToggled = PlayerPrefs.GetInt("isSoundOn") == 1;
        if (isToggled) checkboxImage.SetActive(true);
    }
    public override void Click()
    {
        if (isToggled)
        {
            checkboxImage.SetActive(false);
            AudioListener.volume = 0f;
        } 
        else
        {
            checkboxImage.SetActive(true);
            AudioListener.volume = 1f;
        }
        isToggled = !isToggled;

    }


}
