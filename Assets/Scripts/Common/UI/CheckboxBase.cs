using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckboxBase : ButtonBase
{
    protected bool isToggled;
    public GameObject checkboxImage;

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
    }


}
