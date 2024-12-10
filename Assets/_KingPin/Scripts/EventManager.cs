using MoreMountains.Tools;
using UnityEngine;


public struct TravelingPhaseStarted
{
    public static TravelingPhaseStarted e;

    public static void Trigger()
    {
          MMEventManager.TriggerEvent(e);              
    }
}

public struct TravelingPhaseEnded
{
    public static TravelingPhaseEnded e;

    public static void Trigger()
    {
        MMEventManager.TriggerEvent(e);              
    }
}

public struct PuzzlePhaseStarted
{
    public static PuzzlePhaseStarted e;
    public static void Trigger()
    {
        MMEventManager.TriggerEvent(e);              
    }
}


public struct PuzzlePhaseEnded
{
    public static PuzzlePhaseEnded e;
    public static void Trigger()
    {
        MMEventManager.TriggerEvent(e);              
    }
}

public struct UpgradePhaseStarted
{
    public static UpgradePhaseStarted e;
    public static void Trigger()
    {
        MMEventManager.TriggerEvent(e);              
    }
}

public struct UpgradePhaseEnded
{
    public static UpgradePhaseEnded e;

    public  static void Trigger()
    {
        MMEventManager.TriggerEvent(e);              
    }
}

public struct PinMovement
{
    public static PinMovement e;
    public static void Trigger()
    {
        MMEventManager.TriggerEvent(e);              
    }
}

public struct PuzzleSolved
{
    public static PuzzleSolved e;
    public static void Trigger()
    {
        MMEventManager.TriggerEvent(e);              
    }
}

public struct UpgradeOptionSelected
{
    public static UpgradeOptionSelected e;
    public static void Trigger()
    {
        MMEventManager.TriggerEvent(e);              
    }
}


public struct EnemyMoving
{
    public static EnemyMoving e;
    public Transform CurrentTransform;

    public static void Trigger(Transform currentTransfrom)
    {
        e.CurrentTransform = currentTransfrom;
        MMEventManager.TriggerEvent(e);              
    }
}

public struct EnemyAttacking
{
    public static EnemyAttacking e;
    public Transform CurrentTransform;

    public static void Trigger(Transform currentTransfrom)
    {
        e.CurrentTransform = currentTransfrom;
        MMEventManager.TriggerEvent(e);              
    }
}

public struct PlayerTurnStarted
{
    public static PlayerTurnStarted e;
    public static void Trigger()
    {
        MMEventManager.TriggerEvent(e);              
    }
}

public struct PlayerTurnEndend
{
    public static PlayerTurnEndend e;
    public static void Trigger()
    {
        MMEventManager.TriggerEvent(e);              
    }
}

public struct EnemyDeath
{
    public static EnemyDeath e;
    public Enemy EnemyScript;
    public static void Trigger(Enemy enemyScript)
    {
        e.EnemyScript = enemyScript;
        MMEventManager.TriggerEvent(e);              
    }
}

public struct PlayerDeath
{
    public static PlayerDeath e;
    public static void Trigger()
    {
        MMEventManager.TriggerEvent(e);              
    }
}

public struct LootInteraction
{
    public static LootInteraction e;
    public Transform LootTransform;
    public static void Trigger(Transform lootTransform)
    {
        e.LootTransform = lootTransform;
        MMEventManager.TriggerEvent(e);              
    }
}


public struct LootPoolEmptied
{
    public static LootPoolEmptied e;
    public static void Trigger()
    {
        MMEventManager.TriggerEvent(e);              
    }
}

public struct EnemyFormationDefetead
{
    public static EnemyFormationDefetead e;
    public static void Trigger()
    {
        MMEventManager.TriggerEvent(e);              
    }
}
public class EventManager
{
        
}
