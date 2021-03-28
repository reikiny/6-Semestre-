using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    [Header("DoTween")]
    public float duration;
    public Ease ease;


    void LateUpdate()
    {
        Vector3 target = player.position + offset;
        transform.DOMove(target, duration).SetEase(ease);

    }
}
