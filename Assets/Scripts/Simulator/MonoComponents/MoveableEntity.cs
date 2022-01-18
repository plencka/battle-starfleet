using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LocomotionState
{
    kNone,
    kWander,
    kFollow,
    kFollowMouse,
    kVFormation
}

public abstract class MoveableEntity : MonoBehaviour, ILocomotion<LocomotionState, Vector2>
{
    public LocomotionState _currentState = LocomotionState.kWander;

    public int _formationIndex = 0;
    private float _maxSpeed = 3;
    private float _speedUpValue = 0.5f;
    private float _currentSpeed = 0;
    private float Speed {
        get => _currentSpeed;
        set
        {
            if (value > _maxSpeed)
            {
                _currentSpeed = _maxSpeed;
            }
            else if (value < 0)
            {
                _currentSpeed = 0;
            }
            else
            {
                _currentSpeed = value;
            }
        }
    }

    public Transform _currentTarget;

    private Vector2 targetPoint = new Vector2(0, 0);
    private Vector2 boundArea = new Vector2(5, 5);

    private Vector2 _positionPrevious = new Vector2(0, 0);
    private Vector2 _positionCurrent = new Vector2(0, 0);

    private float _lastChangeTimestamp = 0;
    private readonly float _targetPointChangeDelay = 3;
    public void Start()
    {
        _positionCurrent = transform.position;
    }

    private void MoveTowardsPoint(Vector2 point)
    {
        Speed += _speedUpValue * Time.deltaTime;
        Vector2 dir = point + new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)) - _positionCurrent;
        float angle = Vector2.SignedAngle(transform.up, dir);
        transform.Rotate(new Vector3(0, 0, 1), angle * 1.5f * Time.deltaTime);
        Debug.DrawRay(transform.position, dir, Color.red);
        transform.position += transform.up * _currentSpeed * Time.deltaTime;
    }

    private void None()
    {
        Speed -= 2 * _speedUpValue * Time.deltaTime;
    }
    private void Follow()
    {
        if (_currentTarget)
        {
            MoveTowardsPoint(_currentTarget.position);
        }
        else
        {
            Wander();
        }
    }

    private void FollowMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        var pos = Camera.main.ScreenToWorldPoint(mousePos);
        pos.z = 0;
        MoveTowardsPoint(pos);
    }

    private void VFormation()
    {
        if (_currentTarget)
        {
            var index = _formationIndex+1;
            var offset = _currentTarget.position - (_currentTarget.up * (index /2));
            if (index % 2 == 0)
            {
                offset += _currentTarget.right * (index);
            }
            else
            {
                offset += -_currentTarget.right * (index);
            }
            MoveTowardsPoint(offset);
        }
        else
        {
            Wander();
        }
    }

    private void Wander()
    {
        if(_lastChangeTimestamp + _targetPointChangeDelay < Time.time)
        {
            _lastChangeTimestamp = Time.time;
            targetPoint = new Vector2(Random.Range(-boundArea.x, boundArea.x),
                Random.Range(-boundArea.y, boundArea.y));
        }
        MoveTowardsPoint(targetPoint);
    }

    public float GetCurrentSpeed()
    {
        return _currentSpeed;
    }

    public Transform GetCurrentTarget()
    {
        return _currentTarget;
    }

    public void SetTarget(Transform target)
    {
        _currentTarget = target;
        SetLocomotionState(LocomotionState.kFollow);
    }

    public Vector2 GetCurrentVelocity()
    {
        return (_positionCurrent - _positionPrevious) / Time.deltaTime;
    }

    public void Move()
    {
        _positionPrevious = _positionCurrent;

        switch (_currentState)
        {
            case LocomotionState.kWander:
                Wander();
                break;
            case LocomotionState.kFollow:
                Follow();
                break;
            case LocomotionState.kFollowMouse:
                FollowMouse();
                break;
            case LocomotionState.kNone:
                None();
                break;
            case LocomotionState.kVFormation:
                VFormation();
                break;
            default:
                break;
        }

        _positionCurrent = transform.position;
    }

    public void SetBounds(float x, float y)
    {
        throw new System.NotImplementedException();
    }

    public void SetLocomotionState(LocomotionState state)
    {
        _currentState = state;
    }

    public void SetMaxSpeed(float speed)
    {
        _maxSpeed = speed;
    }
}
