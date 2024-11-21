using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventService 
{
    public EventController OnGenerateButtonPressed;
    public  EventService()
    {
        OnGenerateButtonPressed = new EventController();
    }
}
