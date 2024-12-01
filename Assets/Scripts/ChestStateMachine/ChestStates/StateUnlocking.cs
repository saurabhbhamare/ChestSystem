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
        Owner.chestView.StartCoroutine(StartUnlockTimer());
    }

    public void OnStateExit()
    {
        Owner.chestView.StopCoroutine(StartUnlockTimer());
    }

    public void Update()
    {
    }
    private IEnumerator StartUnlockTimer()
    {
        float remainingTime = Owner.chestModel.UnlockTime;
        while(remainingTime>0)
        {
             Owner.chestView.SetChestStatus(string.Format("{0:00}:{1:00}", Mathf.FloorToInt(remainingTime / 60), Mathf.FloorToInt(remainingTime % 60)));
     //    Owner..SetChestStatus(string.Format("{0:00}:{1:00}", Mathf.FloorToInt(remainingTime / 60), Mathf.FloorToInt(remainingTime % 60)));
            yield return new WaitForSeconds(1);
            remainingTime -= 1;

        }
        //Owner.chestView.SetChestStatusText("Unlocked!"); 
        chestStateMachine.ChangeChestState(ChestStates.UNLOCKED);
    }
}
