using UnityEngine;

namespace Code.OnLand {
   public class BounceOnLand : FakePhysicsOnLand {
      private const float _EPSILON = .0001f;

      [Range(0f, 1f)] public float factor;
      [Min(0)]        public int   maxCount;
      public                 bool  maxCountEnabled;

      private int _bouncesCount;
      


      protected override void OnLand() {
         if (maxCountEnabled) {
            if (_bouncesCount > maxCount) {
               enabled = false;
               return;
            }
            _bouncesCount++;
         }
         
         physics.Launch(
            physics.Direction,
            FactoredHeight(),
            FactoredDistance(),
            Mathf.Max(FactoredDuration(), _EPSILON)
         );
      }


      private float FactoredHeight()   => physics.Height   * factor;
      private float FactoredDistance() => physics.Distance * factor;
      private float FactoredDuration() => physics.Duration * factor;
   }
}