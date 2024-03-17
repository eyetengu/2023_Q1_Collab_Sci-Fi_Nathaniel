using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewMember_05 : NPC_Activities
{    
    public override void MoveToDestination()
    {
        base.MoveToDestination();   
    }

    public override void PerformWorkFunctions()
    {
        base.PerformWorkFunctions();    
    }

    public override void ChooseARandomStation()
    {
        base.ChooseARandomStation();
    }

    public override IEnumerator StationChangeTimer()
    {
        return base.StationChangeTimer();
    }

}
