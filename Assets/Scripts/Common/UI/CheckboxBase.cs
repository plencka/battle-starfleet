using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CheckboxBase : ButtonBase
{
    protected bool isToggled;
    public GameObject checkboxImage;

    public void Toggle()
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
