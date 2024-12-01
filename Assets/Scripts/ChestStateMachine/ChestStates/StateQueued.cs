using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateQueued : IState
{
    public ChestController Owner { get; set; }
    private ChestStateMachine chestStateMachine;
    public StateQueued(ChestStateMachine chestStateMachine)
    {
        this.chestStateMachine = chestStateMachine;
    }

    public void OnStateEnter()
    {
        Owner.chestView.SetChestStatus("Queued");
    }

    public void OnStateExit()
    {
        
    }

    public void Update()
    {
    }
}
 