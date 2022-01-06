using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBase : MonoBehaviour, IClickable
{
    public abstract void Click();

    protected void Start()
    {
        Button button = GetComponent<Button>();
        if (!button)
        {
            Debug.LogError("Button Script needs to be attached to the GameObject with Button Component", this.gameObject);
            return;
        }

        button.onClick.AddListener(Click);
    }
}
