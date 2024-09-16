using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthIncrease
{
    int HealthMax{ get; set; }

    void IncreaseMaxHealth(int increase);
}
