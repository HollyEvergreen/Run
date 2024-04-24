using System;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float Accuracy;
    public float Accuracy_Mult;
    public Damage Damage;
    public playerController Player;
    public float Health;


    MonsterType monsterType;
    private void Start()
    {
        Player = Camera.main.GetComponent<playerController>();
        switch (monsterType)
        {
            case MonsterType.NORM:
                Accuracy = 0.35f;
                Damage.value = 5f * UnityEngine.Random.Range(0.15f, 2f);
                break;
            default:
                Accuracy = UnityEngine.Random.Range(0.2f, 0.8f);
                Damage.value = 5f * UnityEngine.Random.Range(0.15f, 2f);
                break;
        }

        Accuracy *= Accuracy_Mult;
    }

    private void Update()
    {
        var t = (math.frac(Time.time / 2f));
        if (t < 0.1f)
        {
            print(t);
            if (UnityEngine.Random.value < Accuracy)
            {
                Player._Damage(Damage);
            }
        }
        //Vector3 dir = transform.position - Player.transform.position;
        //transform.rotation = Quaternion.Euler(Vector3.up * Vector3.SignedAngle(Vector3.forward, dir, Vector3.up));

        if (Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void _Damage(Damage damage)
    {
        print(damage.value);
        Health -= damage.value;
    }
}