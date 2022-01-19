using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactionSelectionMenu : MonoBehaviour
{
    [SerializeField]
    private TeamManager leftTeam;

    [SerializeField]
    private TeamManager rightTeam;

    [SerializeField]
    private List<Faction> factions = new List<Faction>();

    private Area playBounds = new Area(10,10);

    public List<Faction> GetFactions()
    {
        return factions;
    }

    public void GenerateSimulation()
    {
        gameObject.SetActive(false);
        CreateUnits(25, ShipSet.ShipTypes.kFighter, leftTeam.GetFaction());
        CreateUnits(25, ShipSet.ShipTypes.kFighter, rightTeam.GetFaction());
    }

    void CreateUnits(int count, ShipSet.ShipTypes type, Faction faction)
    {
        GameObject prefab = faction
            .GetShipSet()
            .GetShipType(type)
            .GetPrefab();
        for (int i = 0; i < count; i++)
        {
            GameObject ship = Instantiate(prefab);
            ship.transform.position = playBounds.GetRandomPointInArea();
            ship.GetComponent<VehicleEntity>().SetOwner(faction);
            ship.GetComponent<VehicleEntity>().SetShipType(faction.GetShipSet().GetShipType(type));
            ship.GetComponent<VehicleEntity>().SetPlayArea(playBounds);
        }
    }

    private void AssignNextTeam(TeamManager teamSelector)
    {
        foreach(Faction faction in factions)
        {
            if(faction != leftTeam.GetFaction() && faction != rightTeam.GetFaction())
            {
                teamSelector.SelectFaction(faction);
                return;
            }
        }
        Debug.LogError("Not enough factions!");
    }

    private void UpdateDropDown(TeamManager team, TeamManager oppositeTeam)
    {
        Dropdown dropper = team.GetDropdown();
        List<string> options = new List<string>();
        int factionIndex = 0;
        int currentFactionIndex = 0;
        foreach (var option in factions)
        {
            if (option != oppositeTeam.GetFaction())
            {
                options.Add(option.GetName());
                factionIndex++;
            }
            if (option == team.GetFaction())
            {
                currentFactionIndex = factionIndex-1;
            }
            dropper.ClearOptions();
            dropper.AddOptions(options);
            dropper.SetValueWithoutNotify(currentFactionIndex);
        }
    }

    public void PopulateDropDowns()
    {
        UpdateDropDown(leftTeam, rightTeam);
        UpdateDropDown(rightTeam, leftTeam);
    }

    public void AssignNextTeamLeft()
    {
        AssignNextTeam(leftTeam);
    }

    public void AssignNextTeamRight()
    {
        AssignNextTeam(rightTeam);
    }

    private void Start()
    {
        AssignNextTeamLeft();
        AssignNextTeamRight();
        PopulateDropDowns();
    }
}
