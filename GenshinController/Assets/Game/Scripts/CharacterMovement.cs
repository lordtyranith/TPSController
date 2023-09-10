using KinematicCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public struct CharacterMovementInput
{
    public Vector2 MoveInput;
}

[RequireComponent(typeof(KinematicCharacterMotor))]
public class CharacterMovement : MonoBehaviour, ICharacterController
{
    public KinematicCharacterMotor motor;
    [SerializeField] private Vector3 velocityIncrement;
    private Vector3 moveInput;


    private void Awake()
    {
        motor.CharacterController = this;
    }

    public void SetInput(in CharacterMovementInput input)
    {
        moveInput = Vector3.zero;
        if(input.MoveInput != Vector2.zero)
        {
            moveInput = new Vector3(input.MoveInput.x, 0, input.MoveInput.y).normalized;
        }
    }
    public void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
    {
        //throw new NotImplementedException();
    }

    public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
    {
        currentVelocity += velocityIncrement * deltaTime;
        //Debug.Log(currentVelocity);
    }

    #region Not Implemented
   


    void ICharacterController.BeforeCharacterUpdate(float deltaTime)
    {
    }

    void ICharacterController.PostGroundingUpdate(float deltaTime)
    {
    }

    void ICharacterController.AfterCharacterUpdate(float deltaTime)
    {
    }

    bool ICharacterController.IsColliderValidForCollisions(Collider coll)
    {
        return true;
    }

    void ICharacterController.OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
    {
    }

    void ICharacterController.OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
    {
    }

    void ICharacterController.ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
    {
    }

    void ICharacterController.OnDiscreteCollisionDetected(Collider hitCollider)
    {
    }
    #endregion
}
