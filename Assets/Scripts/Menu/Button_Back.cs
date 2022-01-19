using UnityEngine;

public class Button_Back : ButtonBase
{
    [SerializeField]
    private GameObject optionsScreen;
    [SerializeField]
    private GameObject menuScreen;
    public override void Click()
    {
        optionsScreen.SetActive(false);
        menuScreen.SetActive(true);
    }
}
