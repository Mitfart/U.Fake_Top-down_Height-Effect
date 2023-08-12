using Code;
using UnityEngine;

namespace OnLand {
   public class SlowDownOnLand : FakePhysicsOnLand {
      [Range(0f, 1f)] public float factor;

      protected override void OnLand() {
         physics.SetDistance(
            physics.Distance * (1f - factor)
         );
      }
   }
}