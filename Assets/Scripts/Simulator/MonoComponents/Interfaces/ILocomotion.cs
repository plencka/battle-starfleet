using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILocomotion<StateFlags>
{
    void Move();
    void SetMaxSpeed(float speed);
    float GetCurrentSpeed();
    void SetLocomotionState(StateFlags state);
    void SetTarget(GameObject target);
    GameObject GetCurrentTarget();
}
