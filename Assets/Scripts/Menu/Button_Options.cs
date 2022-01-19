using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Button_Options : ButtonBase
{
    [SerializeField]
    private GameObject optionsScreen;
    [SerializeField]
    private GameObject menuScreen;
    public override void Click()
    {
        optionsScreen.SetActive(true);
        menuScreen.SetActive(false);
    }
}
