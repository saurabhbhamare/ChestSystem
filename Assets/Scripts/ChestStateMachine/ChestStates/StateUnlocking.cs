using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateUnlocking : IState
{
    public ChestController Owner { get; set; }
    private ChestStateMachine chestStateMachine;
    public StateUnlocking(ChestStateMachine chestStateMachine)
    {
        this.chestStateMachine = chestStateMachine;
    }

    public void OnStateEnter()
    {
        Owner.chestView.StartCoroutine(StartTimer());
    }

    public void OnStateExit()
    {
        Owner.chestView.StopCoroutine(StartTimer());
    }

    public void Update()
    {
    }
    private IEnumerator StartTimer()
    {
        while(Owner.chestModel.CurrentUnlockTime>0 && chestStateMachine.GetCurrentState()== ChestStates.UNLOCKING)
        {
        //    Mathf.Max(Owner.chestModel.CurrentUnlockTime -= Time.deltaTime, 0);
            this.Owner.chestView.SetChestStatus(string.Format("{0:00}:{1:00}:{2:00}", Mathf.FloorToInt(Owner.chestModel.CurrentUnlockTime / 3600),
            Mathf.FloorToInt((Owner.chestModel.CurrentUnlockTime % 3600) / 60), Mathf.FloorToInt(Owner.chestModel.CurrentUnlockTime % 60)));
            yield return new WaitForEndOfFrame();
        }
    }
}
