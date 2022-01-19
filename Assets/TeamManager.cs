using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamManager : MonoBehaviour
{
    [SerializeField]
    private FactionSelectionMenu parentMenu;

    private Faction selectedFaction;

    [SerializeField]
    private GameObject iconUIElement;

    [SerializeField]
    private GameObject nameUIElement;

    [SerializeField]
    private Dropdown dropdown;

    public Faction GetFaction()
    {
        return selectedFaction;
    }

    public Dropdown GetDropdown()
    {
        return dropdown;
    }

    public void SelectFromDropdown()
    {
        foreach (Faction faction in parentMenu.GetFactions())
        {
            if (dropdown.options[dropdown.value].text.Equals(faction.GetName()))
            {
                SelectFaction(faction);
                return;
            }
        }
    }
    public void SelectFaction(Faction faction)
    {
        selectedFaction = faction;
        iconUIElement.GetComponent<Image>().sprite = selectedFaction.GetIconFile();
        iconUIElement.GetComponent<Image>().color = selectedFaction.GetColor();
        nameUIElement.GetComponent<Text>().text = selectedFaction.GetName();
        parentMenu.PopulateDropDowns();
    }
}
