using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CheckboxBase : ButtonBase
{
    protected bool isToggled;
    private GameObject checkmarkObject;

    protected void Start()
    {
        base.Start();
        checkmarkObject = transform.Find("Checkmark").gameObject;
        isToggled = checkmarkObject.activeSelf;
    }

    public abstract void Toggle();

    public override void Click()
    {
        if (isToggled)
        {
            SetToggle(false);
        }
        else
        {
            SetToggle(true);
        }

        Toggle();
    }

    public void SetToggle(bool status)
    {
        if (isToggled != status)
        {
            checkmarkObject.SetActive(status);
            isToggled = !isToggled;
        }
    }
}
