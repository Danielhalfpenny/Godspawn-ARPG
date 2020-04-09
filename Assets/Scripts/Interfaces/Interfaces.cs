using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A list of interfaces to be used in Godspawn
/// A Enum for Rarity
/// </summary>

public interface ISpell
{
    /// <summary>
    /// Description -> [string] -> In game description
    /// Cost -> [int] -> How much resource is needed to cast
    /// CastSpeed -> [int] -> Cast speed, milliseconds
    /// Cast -> [Method] -> Cast the spell
    /// </summary>
    
    string Description { get; }
    int Cost { get; }
    int CastSpeed { get; }
    
    void Cast();
}

public interface IDamageSpell : ISpell
{
    /// <summary>
    /// Damage -> [int] -> base damage
    /// </summary>
    int Damage { get; }
}

public interface IHealSpell : ISpell
{
    /// <summary>
    /// Heal -> [int] -> base heal
    /// </summary>
    int Heal { get; }
}

public interface ITargetable
{
    /// <summary>
    /// For when using Targeting
    /// 
    /// StartTargeting -> [method] -> Create and use target
    /// StopTargeting -> [method] => Destroy and stop target
    /// </summary>
    void StartTargeting();

    void StopTargeting();
}

public interface IItem
{
    /// <summary>
    /// Description -> [string] -> description of item
    /// Value -> [int] -> current value of item
    /// Rarity -> [rarity] -> enum, rarity of item
    /// </summary>
    string Description { get; set; }
    int Value { get; set; }
    RarityEnum Rarity { get; set; }
}

public interface IEquipable
{
    // Placeholder
}

public interface IWeapon : IItem, IEquipable
{
    /// <summary>
    /// Parry -> [float] -> parry chance
    /// </summary>
    float Parry { get; set; }
}

public interface IArmour : IItem, IEquipable
{
    /// <summary>
    /// Block -> [float] -> block chance
    /// </summary>
    float Block { get; set; }
}

public interface IDamageable
{
    /// <summary>
    /// DealDamage -> [method(int)] -> To be called when taking damage, int is damage taken
    /// </summary>
    void DealDamage(int damage);

}

public interface IKillable
{
    /// <summary>
    /// Kill -> [method] -> To be called on killed
    /// </summary>
    void Kill();

}

public interface IEnemy : IDamageable, IKillable
{
    /// <summary>
    /// Health -> [int] -> max health
    /// Block -> [int] -> block chance
    /// Parry -> [int] => Parry chance
    /// Target -> [GameObject] -> Target Player to attack/chase
    /// </summary>
    int Health { get; set; }
    float MoveSpeed { get; set; }
    int Parry { get; set; }
    int Block { get; set; }
    GameObject Target { get; set; }
    
}

public interface IPlayer : IDamageable, IKillable
{
    /// <summary>
    /// Health -> [int] -> player current health
    /// MaxHealth -> [int] -> player max health
    /// Armour -> [int] -> player armour
    /// Block -> [int] -> block stat
    /// Parry -> [int] -> parry stat
    /// Evasion -> [int] -> Float stat
    /// MoveSpeed -> [float] -> player move speed
    /// Items -> [List<IItem>] -> List of items
    /// Spells -> [List<ISpell>] -> List of spells
    /// Kill -> [method] -> To be called on death
    /// Interact -> [method] -> To be called with an IInteractable object
    /// </summary>
    int Health { get; set; }
    int MaxHealth { get; set; }
    int Armour { get; set; }
    int Block { get; set; }
    int Parry { get; set; }
    int Evasion { get; set; }
    float MoveSpeed { get; set; }
    List<IItem> Items { get; set; }
    List<ISpell> Spells { get; set; }

    void Kill();
    void Interact(IInteractable interactObj);
}

public interface IInteractable
{
    /// <summary>
    /// Interacted -> [method] -> to be called when interacted with
    /// </summary>
    void Interacted();
}

public enum RarityEnum
{
    /// <summary>
    /// Enumerator for rarity.
    /// </summary>
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}