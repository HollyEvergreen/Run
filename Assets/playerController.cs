using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    [SerializeField]
    private GameObject _Gun;

    public InputActionMap inputActions;

    public Camera MainCamera;
    Damage Damage;

    public float Health;

    public bool Firing { get; private set; }
    public float FireStart { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        inputActions.Enable();
        MainCamera = Camera.main;
        Damage = new Damage(10f, DamageType.NORM);
    }

    // Update is called once per frame
    void Update()
    {
        inputActions.actionTriggered += InputTrigger;
        if (Firing)
        {
            if (Time.time - FireStart > 3f)
            {
                Firing = false;
            }
            else
            {
                Fire();
            }
        }
        if (Health <=  0)
        {
            Die();
        }
    }

    private void Die()
    { 
        SceneManager.LoadScene(2);
        Destroy(gameObject);
    }

    private void InputTrigger(InputAction.CallbackContext obj)
    {
        print(obj.phase);
        switch (obj.phase)
        {
            case InputActionPhase.Performed:
                switch (obj.action.name)
                {
                    case "Fire":
                        if (!Firing)
                        {
                            Firing = true;
                            FireStart = Time.time;
                        }
                        break;
                    default:
                        break;
                }
                break;
            case InputActionPhase.Canceled:
                switch (obj.action.name)
                {
                    case "Fire":
                        Firing = false;
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
        
    }

    private void Fire()
    {
        _Gun.GetComponent<Gun>().AnimTrigger();

        bool hit = Physics.Raycast(MainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo);
        if (!hit) return;

        if (!hitInfo.transform.gameObject.CompareTag("Enemy")) return;

        print($"HIT {hitInfo.transform.gameObject.name}");
        hitInfo.transform.GetComponent<Enemy>()._Damage(Damage);
    }

    public void _Damage(Damage damage)
    {
        print(damage.value);
        Health -= damage.value;
        return;
    }
}

public struct Damage
{
    public float value;
    public DamageType type;

    public Damage(float value, DamageType type)
    {
        this.value = value;
        this.type = type;
    }

    public float CalculateDamage(MonsterType Type)
    {
        string Match = ((int)Type).ToString() + ((int)type).ToString();
        switch (Match)
        {
            case "00":
                return value;
            default:
                return value;
        }
    }
    public float CalculateDamage(DamageType Type)
    {
        string Match = ((int)Type).ToString() + ((int)type).ToString();
        switch (Match)
        {
            case "00":
                return value;
            default:
                return value;
        }
    }
}

public enum DamageType
{
    NORM,
}

public enum MonsterType
{
    NORM,
}