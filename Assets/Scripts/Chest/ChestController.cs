using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController 
{
    public ChestView chestView;
    public ChestModel chestModel;


    //chest state machine

    private ChestStateMachine chestStateMachine;

  public ChestController(ChestData chestData,ChestView chestView,Transform parentTransform, EventService eventService)
    {
        chestModel = new ChestModel(chestData);
        this.chestView = GameObject.Instantiate<ChestView>(chestView, parentTransform);
        //SetChestName();
        CreateChestStateMachine();
        ChangeChestState(ChestStates.LOCKED);
        

    }
    public ChestStates GetChestState() => chestStateMachine.GetCurrentState();
    public void SetChestName()
    {
        if(chestModel.ChestType == ChestType.COMMON)
        {
            chestView.SetChestName("COMMON");
        }
        else if(chestModel.ChestType == ChestType.EPIC)
        {
            chestView.SetChestName("EPIC");
        }
        else if(chestModel.ChestType == ChestType.LEGENDARY)
        {
            chestView.SetChestName("LEGENDARY");
        }
        else
        {
            chestView.SetChestName("RARE");
        }
    }
    private void CreateChestStateMachine()
    {
        Debug.Log("Create state machine ");
        chestStateMachine = new ChestStateMachine(this);
    }
    public void ChangeChestState(ChestStates state) => chestStateMachine.ChangeChestState(state);
    public void RemoveGameObject() => GameObject.Destroy(chestView.gameObject);
}
