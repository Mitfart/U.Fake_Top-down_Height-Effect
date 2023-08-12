using System;
using UnityEngine;

namespace Code {
   public class FakePhysics : MonoBehaviour {
      private const float _EPSILON = .0001f;

      public FakeHeight fakeHeight;

      private float _dividedDuration;

      public event Action OnLand;

      public Vector2 Direction { get; private set; }
      public float   Height    { get; private set; }
      public float   Distance  { get; private set; }
      public float   Duration  { get; private set; }

      public Vector2 HorVelocity { get; private set; }
      public float   VerVelocity { get; private set; }
      public float   Mass        { get; private set; }
      public bool    IsGrounded  { get; private set; }



      private void Update() {
         Move();
         CheckLanding();
      }



      public void Launch(Vector2 direction, float height, float distance, float duration) {
         Direction = direction;
         Height    = Mathf.Max(0f, height);
         Distance  = distance;
         Duration  = duration;

         _dividedDuration = 1f / Duration;

         IsGrounded = height <= _EPSILON;

         CalcHorVelocity();
         CalcVerVelocity();
      }



      public void SetDirection(Vector2 direction) {
         Direction = direction;
         CalcHorVelocity();
      }

      public void SetHeight(float height) {
         Height = height;
         CalcVerVelocity();
      }

      public void SetDistance(float distance) {
         Distance = distance;
         CalcHorVelocity();
      }

      public void SetDuration(float duration) {
         Duration = duration;
         CalcDuration();
         CalcHorVelocity();
         CalcVerVelocity();
      }



      private void Move() {
         float delta = Time.deltaTime;

         VerVelocity       -= Mass        * delta;
         fakeHeight.Height += VerVelocity * delta;

         transform.position += (Vector3)HorVelocity * delta;
      }

      private void CheckLanding() {
         if (AboveGround() || IsGrounded)
            return;

         IsGrounded = true;
         OnLand?.Invoke();
      }



      private bool AboveGround() => fakeHeight.Height > _EPSILON;



      private void CalcDuration() {
         _dividedDuration = 1f / Duration;
      }

      private void CalcHorVelocity() {
         HorVelocity = Direction * (Distance * _dividedDuration);
      }

      private void CalcVerVelocity() {
         VerVelocity = Height      * _dividedDuration * 2f;
         Mass        = VerVelocity * _dividedDuration;
      }
   }
}