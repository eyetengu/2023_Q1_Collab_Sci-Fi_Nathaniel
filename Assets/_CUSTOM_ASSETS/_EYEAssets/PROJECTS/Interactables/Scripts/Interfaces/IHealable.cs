using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealable
{
    public int Health { get; set; }

    public void Heal(int healAmount);
}
