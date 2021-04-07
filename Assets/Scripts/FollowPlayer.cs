using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class FollowPlayer : Enemy
{

    [PropertyOrder(2)]
    public List<Vector3> targetPositions;

    [PropertyOrder(2)]
    public GameObject inicialTarget;

    [PropertyOrder(2)]
    public float seeRange;

    [PropertyOrder(2)]
    public float duration;

    private int _index;
    private bool _beginAction;
    private Transform _playerTransform;
    private Vector3 _playerOldPos;

    private void Start()
    {
        inicialTarget.transform.parent = null;
        targetPositions.Add(inicialTarget.transform.position);
    }
    void Update()
    {
        Bater();
        UI();
        
        RaycastHit hit;
        bool haveSeen = Physics.Raycast(pos.position, pos.forward, out hit, seeRange);

        if (haveSeen)
        {

            if (hit.collider.CompareTag("Player") && !_beginAction)
            {
                _playerTransform = hit.collider.transform;
                _playerOldPos = _playerTransform.position;
            }

            _beginAction = true;
        }

        if (_beginAction)
        {
            if (Turns.enemyTurn)
            {
                targetPositions.Add(_playerOldPos);
                _playerOldPos = _playerTransform.position;

            }
            RaycastHit hit2;
            bool haveHit = Physics.Raycast(pos.position, pos.forward, out hit2, range);
            if (targetPositions.Count > 1 && !haveHit)
                Move();
        }
    }




    public void Move()
    {
        transform.LookAt(targetPositions[1]);

        if (Vector3.Distance(transform.position, targetPositions[0]) > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPositions[0], duration * Time.deltaTime);
        }
        else
        {
            targetPositions.RemoveAt(0);
        }
    }
}
