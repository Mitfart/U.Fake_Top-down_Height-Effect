using Code;

namespace OnLand {
   public class DestroyOnLand : FakePhysicsOnLand {
      protected override void OnLand() => Destroy(physics.gameObject);
   }
}