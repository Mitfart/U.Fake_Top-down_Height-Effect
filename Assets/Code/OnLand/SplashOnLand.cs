using UnityEngine;

namespace Code {
   public class SplashOnLand : FakePhysicsOnLand {
      public Splash splashPrefab;
      public bool   transferVelocity;

      protected override void OnLand() {
         Transform physicsT = physics.transform;
         Splash splash = Instantiate(
            splashPrefab,
            physicsT.position,
            physicsT.rotation,
            physicsT.parent
         );

         if (transferVelocity)
            splash.velocity = physics.HorVelocity;

         splash.Play();
      }
   }
}