using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoison
{
    public bool Poisoned { get; set; }
    public int PoisonPower { get; set; }
    public float PoisonSpeed { get; set; }

    public void PlayersPoisonControl(bool condition, float speed, int power);
}
