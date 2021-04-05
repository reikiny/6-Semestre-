using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class Patrol : Enemy
{

    [PropertyOrder(2)]
    public Instantiate instantiate;

    [PropertyOrder(2)]
    public float duration;

    private int _index;
    private bool positive;

    private void Update()
    {
        Bater();
        UI();
        if (Turns.enemyTurn) ChangeIndex();

        Walk();
    }

    private void ChangeIndex()
    {
        if (positive) _index++;
        else _index--;
    }

    private void Walk()
    {
        if (_index == 0)
        {
            positive = true;
            transform.LookAt(instantiate.waypoints[_index + 1].transform);
        }
        else if (_index == instantiate.waypoints.Count - 1)
        {
            transform.LookAt(instantiate.waypoints[_index - 1].transform);
            positive = false;
        }
        else transform.LookAt(instantiate.waypoints[_index].transform);

        transform.position = Vector3.MoveTowards(transform.position, instantiate.waypoints[_index].transform.position, duration * Time.deltaTime);
    }

}
