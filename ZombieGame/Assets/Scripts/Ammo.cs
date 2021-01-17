﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {

    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    public class AmmoSlot {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public void DecreaseAmmo(AmmoType ammoType) {
        GetAmmoSlot(ammoType).ammoAmount--;
    }

    public void IncreaseAmmo(AmmoType ammoType, int ammoAmount) {
        GetAmmoSlot(ammoType).ammoAmount += ammoAmount;
    }

    public int CountAmmo(AmmoType ammoType) {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType) {

        foreach (AmmoSlot slot in ammoSlots) {
            if (slot.ammoType == ammoType) {
                return slot;
            }  
        }
        return null;
    }

}
