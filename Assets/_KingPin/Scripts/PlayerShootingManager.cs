using System;
using System.Collections;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class PlayerShootingManager : MonoBehaviour, MMEventListener<PlayerTurnStarted>, MMEventListener<PlayerTurnEndend>
{

    [SerializeField] private Transform weaponHolder;
    private Weapon weapon;
    
    
    void Start()
    {
        if (weaponHolder)
        {
            StartCoroutine(SetWeapon());
        }
        else
        {
            Debug.LogError($"No se seteo un Weapon Holder en: {gameObject.name}");
        }
    }

    IEnumerator SetWeapon()
    {
        yield return new WaitUntil(() => weaponHolder.transform.childCount > 0);
        if (weaponHolder.transform.GetChild(0).GetComponent<Weapon>())
        {
            weapon = weaponHolder.transform.GetChild(0).GetComponent<Weapon>();
        }
        else
        {
            Debug.LogError("El primer hijo del Weapon Holder no tiene un componenete Weapon.");
        }
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }


    public void Shoot()
    {
        PlayerShootEvent.Trigger();
        Invoke(nameof(ShootRequest),0f);
    }

    public void EnableAiming()
    {
        weapon.GetComponent<WeaponAim2D>().enabled = true;
    }

    public void DisableAiming()
    {
        weapon.GetComponent<WeaponAim2D>().enabled = false;
    }

    public void ShootRequest()
    {
        if (weapon)
        {
            weapon.WeaponInputStart(); 
        }
        else
        {
            Debug.LogError($"No se seteo ningun arma");
        }
    }

    private void OnTurnStarted()
    {
        EnableAiming();
    }

    private void OnTurnEnded()
    {
        DisableAiming();
    }


    public void OnMMEvent(PlayerTurnStarted eventType)
    {
        OnTurnStarted();
    }

    public void OnMMEvent(PlayerTurnEndend eventType)
    {
        OnTurnEnded();
    }
    
    private void OnEnable()
    {
        this.MMEventStartListening<PlayerTurnStarted>();
        this.MMEventStartListening<PlayerTurnEndend>();
    }
    private void OnDisable()
    {
        this.MMEventStopListening<PlayerTurnStarted>();
        this.MMEventStopListening<PlayerTurnEndend>();
    }
}
