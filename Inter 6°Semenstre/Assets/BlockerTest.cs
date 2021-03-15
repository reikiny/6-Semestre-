using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class BlockerTest : MonoBehaviour
{
    public void Start()
    {
        var blocker = GetComponent<SingleNodeBlocker>();
        blocker.BlockAtCurrentPosition();
    }
}
