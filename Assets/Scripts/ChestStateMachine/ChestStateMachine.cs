using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestStateMachine
{
    private ChestController Owner;
    private IState currentState;
    public Dictionary<ChestStates, IState> States = new Dictionary<ChestStates, IState>();

    public ChestStateMachine(ChestController chestController)
    {
        Owner = chestController;
        CreateChestStates();
        SetOwner();
    }
    private void CreateChestStates()
    {
        States.Add(ChestStates.LOCKED, new StateLocked(this));
        States.Add(ChestStates.UNLOCKED, new StateUnlocked(this));
        States.Add(ChestStates.UNLOCKING, new StateUnlocking(this));
        States.Add(ChestStates.QUEUED, new StateQueued(this));
    }
    private void SetOwner()
    {
        foreach (IState state in States.Values)
        {
            state.Owner = Owner;
        }
    }
    protected void ChangeState(IState newState)
    {
        currentState?.OnStateExit();
        currentState = newState;
        currentState?.OnStateEnter();
    }
    public ChestStates GetCurrentState()
    {
        foreach (KeyValuePair<ChestStates, IState> key in States)
        {
            if (EqualityComparer<IState>.Default.Equals(key.Value, currentState))
            {
                return key.Key;
            }
        }
        throw new KeyNotFoundException("The specified value was not found in the dictionary.");
    }
    public void ChangeChestState(ChestStates newState) => ChangeState(States[newState]);
}