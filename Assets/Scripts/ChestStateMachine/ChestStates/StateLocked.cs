using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateLocked : IState
{
    public ChestController Owner { get; set; }
    private ChestStateMachine chestStateMachine;
    public StateLocked(ChestStateMachine chestStateMachine)
    {
        this.chestStateMachine = chestStateMachine;
    }
    public void OnStateEnter()
    {
        Owner.chestView.SetChestImage(Owner.chestModel.ChestClosedImage);
        Owner.chestView.SetChestName(Owner.chestModel.ChestName);
    }
    public void OnStateExit() { }
    public void Update() { }
}
