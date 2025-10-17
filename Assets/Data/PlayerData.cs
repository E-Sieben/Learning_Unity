using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObject/PlayerData")]
public class PlayerData : ScriptableObject
{
    public Item selectedItem;
    public bool isReleased;
    public Stats stats;
    public Items items;
}

[Serializable]
public struct Stats
{
    public float movementSpeed;
    public float rotationSpeed;
    public float magnetStrength;
    public float pickupRange;
    public float placementCooldown;
}

[Serializable]
public struct Items
{
    public int scraps;
    public int teleporters;
}

public enum Item
{
    Scrap,
    Teleporter
}