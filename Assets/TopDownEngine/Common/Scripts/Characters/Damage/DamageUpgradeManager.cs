using UnityEngine;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;

public class DamageUpgradeManager : MonoBehaviour
{
    public static DamageUpgradeManager Instance;

    [Tooltip("Factor multiplicador del daño. Úsalo para aumentar o reducir el daño.")]
    [SerializeField] private float DamageUpgradePercentage = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Aplica el porcentaje de mejora de daño a un objeto DamageOnTouch.
    /// </summary>
    /// <param name="damageOnTouch">El componente DamageOnTouch del objeto</param>
    public void ApplyDamageUpgrade(DamageOnTouch damageOnTouch)
    {
        // Calculamos el porcentaje adicional del daño
        float additionalMinDamage = damageOnTouch.MinDamageCaused * (DamageUpgradePercentage / 100f);
        float additionalMaxDamage = damageOnTouch.MaxDamageCaused * (DamageUpgradePercentage / 100f);

        // Sumamos el porcentaje al daño base
        damageOnTouch.MinDamageCaused += additionalMinDamage;
        damageOnTouch.MaxDamageCaused += additionalMaxDamage;
    }

    /// <summary>
    /// Restaura el daño original en un objeto DamageOnTouch (sin el porcentaje adicional).
    /// Esto es útil cuando quieres desactivar mejoras o upgrades temporales.
    /// </summary>
    /// <param name="damageOnTouch">El componente DamageOnTouch del objeto</param>
    /// <param name="originalMinDamage">El daño mínimo original</param>
    /// <param name="originalMaxDamage">El daño máximo original</param>
    public void ResetDamage(DamageOnTouch damageOnTouch, float originalMinDamage, float originalMaxDamage)
    {
        damageOnTouch.MinDamageCaused = originalMinDamage;
        damageOnTouch.MaxDamageCaused = originalMaxDamage;
    }
}