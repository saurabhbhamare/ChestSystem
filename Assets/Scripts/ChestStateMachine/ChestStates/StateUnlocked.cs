using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateUnlocked : IState
{
    public ChestController Owner { get; set; }
    private ChestStateMachine chestStateMachine;
    public StateUnlocked(ChestStateMachine chestStateMachine)
    {
        this.chestStateMachine = chestStateMachine;
    }

    public void OnStateEnter()
    {
        Owner.chestView.SetChestImage(Owner.chestModel.ChestOpenedImage);
        Owner.chestView.SetChestStatus("Unlocked");
    }

    public void OnStateExit()
    {
       
    }

    public void Update()
    {
   
    }
}
