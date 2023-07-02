using System.Collections;
using System.Collections.Generic;
using Endless.Level3.SpawnInfo;
using UnityEngine;
using static PlayerClass;

public class SpikeHeadSpawner : ObjectPool
{
    private float DelayTime = 3f;
    private float DiffRate = 1f;
    private float DiffIncreaseRate = 0.7f;
    private GameObject Player;
    public override void AwakeAction()
    {
        //
    }
    public override void StartAction()
    {
        //
        Player = ICommon.GetPlayerObject();

        StartCoroutine(StartSpawningTop());
        StartCoroutine(StartSpawningTop());
        StartCoroutine(StartSpawningTop());
        StartCoroutine(StartSpawningTop());

        StartCoroutine(StartSpawningRight());
        StartCoroutine(StartSpawningRight());

        StartCoroutine(StartSpawningLeft());
        StartCoroutine(StartSpawningLeft());

        StartCoroutine(IncreaseDifficultyOverTime());
    }
    public override void UpdateAction()
    {
        //
    }

    IEnumerator IncreaseDifficultyOverTime()
    {
        while (Player)
        {
            yield return new WaitForSeconds(DiffRate);
            DelayTime = DelayTime * DiffIncreaseRate;
        }
    }

    IEnumerator StartSpawningTop()
    {
        while (Player)
        {
            yield return new WaitForSeconds(Random.Range(0, DelayTime));
            var new_position = new Vector2(Random.Range(SpawnInfo.x_min, SpawnInfo.x_max), SpawnInfo.y_max);
            GameObject spawned = GetPooledObject();
            if (spawned != null)
            {
                spawned.transform.position = new_position;
                spawned.SetActive(true);
                yield return new WaitForSeconds(2);
                var attack_dir = new Vector2(0, -1);
                spawned.GetComponent<SpikeHead_Endless_v1>().StartAttackAtDir(attack_dir);
            }
        }

    }

    IEnumerator StartSpawningRight()
    {
        while (Player)
        {
            yield return new WaitForSeconds(Random.Range(0, DelayTime));
            var new_position = new Vector2(SpawnInfo.x_max, Random.Range(SpawnInfo.y_min, SpawnInfo.y_max));
            GameObject spawned = GetPooledObject();
            if (spawned != null)
            {
                spawned.transform.position = new_position;
                spawned.SetActive(true);
                yield return new WaitForSeconds(2);
                var attack_dir = new Vector2(-1, 0);
                spawned.GetComponent<SpikeHead_Endless_v1>().StartAttackAtDir(attack_dir);
            }
        }

    }

    IEnumerator StartSpawningLeft()
    {
        while (Player)
        {
            yield return new WaitForSeconds(Random.Range(0, DelayTime));
            var new_position = new Vector2(SpawnInfo.x_min, Random.Range(SpawnInfo.y_min, SpawnInfo.y_max));
            GameObject spawned = GetPooledObject();
            if (spawned != null)
            {
                spawned.transform.position = new_position;
                spawned.SetActive(true);
                yield return new WaitForSeconds(2);
                var attack_dir = new Vector2(1, 0);
                spawned.GetComponent<SpikeHead_Endless_v1>().StartAttackAtDir(attack_dir);
            }
        }

    }
}
