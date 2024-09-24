using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICurable
{
    bool Poisoned { get; set; }

    void PlayerPoisonControl();
}
