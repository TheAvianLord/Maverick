using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariables : MonoBehaviour
{
    private static int money, bikeStats, armorStats, weaponStats, carSpawnRate;

    public static int Money
    {
        get
        {
            return money;
        }
        set
        {
            money = value;
        }
    }

    public static int BikeStats
    {
        get
        {
            return bikeStats;
        }
        set
        {
            bikeStats = value;
        }
    }

    public static int ArmorStats
    {
        get
        {
            return armorStats;
        }
        set
        {
            armorStats = value;
        }
    }

    public static int WeaponStats
    {
        get
        {
            return weaponStats;
        }
        set
        {
            weaponStats = value;
        }
    }


}
