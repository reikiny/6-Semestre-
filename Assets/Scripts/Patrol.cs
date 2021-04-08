using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class Patrol : Enemy
{

    [PropertyOrder(2)]
    [ChildGameObjectsOnly]
    [BoxGroup("PathStats")]
    public Instantiate instantiate;

    [PropertyOrder(2)]
    [BoxGroup("PathStats")]
    public float speed;

    private int _index;
    private bool _positive;
    private bool _tooClose;

    protected override void Inherited()
    {
        base.Inherited();

        if (Turns.enemyTurn)
            ChangeIndex();

        RaycastHit hit;
        bool haveHit = Physics.Raycast(pos.position, pos.forward, out hit, range);
        bool cantWalk = haveHit && hit.collider.CompareTag("Escudeiro");

        if (!cantWalk)
            Walk();
    }

    private void ChangeIndex()
    {
        if (_positive) _index++;
        else _index--;

        _tooClose = false;
    }

    private void RestrictWalk()
    {
        foreach (GameObject go in _enemies)
        {
            if (go == gameObject) continue;
            if (go && Vector3.Distance(go.transform.position, gameObject.transform.position) < 0.6f)
            {
                _tooClose = true;
                break;
            }
        }
    }

    private void Walk()
    {
        if (_index == 0) _positive = true;

        if (_index == instantiate.waypoints.Count - 1) _positive = false;


        if (_positive) transform.LookAt(instantiate.waypoints[_index + 1].transform);
        else transform.LookAt(instantiate.waypoints[_index - 1].transform);

        if (!_tooClose)
        {
            transform.position = Vector3.MoveTowards(transform.position, instantiate.waypoints[_index].transform.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, instantiate.waypoints[_index].transform.position) < 0.5f)
            {
                RestrictWalk();
            }
        }

    }




}
