using UnityEngine;

namespace Code {
   public abstract class FakePhysicsOnLand : MonoBehaviour {
      public FakePhysics physics;

      protected virtual void OnEnable()  => physics.OnLand += OnLand;
      protected virtual void OnDisable() => physics.OnLand -= OnLand;

      protected abstract void OnLand();
   }
}