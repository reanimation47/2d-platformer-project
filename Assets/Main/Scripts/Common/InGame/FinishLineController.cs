using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == ICommon.GetPlayerObject())
        {
            ICommon.StageCompleted();
        }
    }
}
