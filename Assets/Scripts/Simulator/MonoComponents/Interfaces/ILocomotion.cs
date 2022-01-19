using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILocomotion<StateFlags, Vector>
{
    void Move();
    void SetMaxSpeed(float speed);
    void SetBounds(float x, float y);
    float GetCurrentSpeed();
    void SetLocomotionState(StateFlags state);
    void SetTarget(GameObject target);
    GameObject GetCurrentTarget();
    Vector GetCurrentVelocity();
}
