﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using Unity;
using UnityEngine;

public class WeaponStrategy
{
    IWeapon Weapon;
    
    public void SetWeapon(IWeapon weapon)
    {
        Weapon = weapon;
    }
    
    public void Attack()
    {
        Weapon.Attack();
    }
}

