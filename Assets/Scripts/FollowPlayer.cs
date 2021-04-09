using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class FollowPlayer : Enemy
{

    [PropertyOrder(2)]
    [BoxGroup("FollowStats")]
    public GameObject _inicialTarget;

    [PropertyOrder(2)]
    [BoxGroup("FollowStats")]
    public float seeRange;

    [BoxGroup("FollowStats")]
    [PropertyOrder(2)]
    public float speed;

    private int _index;
    private bool _beginAction;
    private bool _tooClose;
    private Transform _playerTransform;
    private Vector3 _playerOldPos;
    private List<Vector3> _targetPositions= new List<Vector3>();

    protected override void Init()
    {
        base.Init();
        _inicialTarget.transform.parent = null;
        _targetPositions.Add(_inicialTarget.transform.position);

    }
    protected override void Inherited()
    {
        base.Inherited();

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
                _targetPositions.Add(_playerOldPos);
                _playerOldPos = _playerTransform.position;
                _tooClose = false;
            }
            RaycastHit hit2;
            bool haveHit = Physics.Raycast(pos.position, pos.forward, out hit2, range);
            bool cantWalk = haveHit && hit2.collider.CompareTag("Escudeiro");

            if (_targetPositions.Count > 1)
                if (!cantWalk)
                    Move();
        }
    }

    public void Move()
    {
        transform.LookAt(_targetPositions[1]);

        if (!_tooClose)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPositions[0], speed * Time.deltaTime);
           // if (Vector3.Distance(transform.position, _targetPositions[0]) < 0.5f)
               // RestrictWalk();

        }
        if (_tooClose || Vector3.Distance(transform.position, _targetPositions[0]) <= 0)
        {
            _targetPositions.RemoveAt(0);
        }

    }

    //Tirei para ver como fica
    private void RestrictWalk()
    {
        foreach (GameObject go in _enemies)
        {
            if (go == gameObject) continue;
            if (Vector3.Distance(go.transform.position, gameObject.transform.position) < 0.6f)
            {
                //_tooClose = true;
                break;
            }
        }
    }
}
