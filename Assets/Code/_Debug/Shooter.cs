using UnityEngine;

namespace Code {
   public class Shooter : MonoBehaviour {
      public Camera     mainCamera;
      public Gun        gun;
      public FakeHeight FakeHeight;

      [Space] //
      public Vector2 height;
      public Vector2 distance;
      public Vector2 duration;

      [Space] //
      public FakePhysics mainProjectile;
      public FakePhysics secondProjectile;



      private void Update() {
         gun.Rotate2D(at: AimPoint());

         if (MainShootInput())
            gun.Shoot(
               FakeHeight.Height,
               mainProjectile,
               height.Random(),
               distance.Random(),
               duration.Random()
            );

         if (SecondShootInput())
            gun.Shoot(
               FakeHeight.Height,
               secondProjectile,
               height.Random(),
               distance.Random(),
               duration.Random()
            );
      }

      private        Vector3 AimPoint()         => Mouse() + Height();
      private        Vector3 Height()           => Vector3.up * FakeHeight.Height;
      private        Vector3 Mouse()            => mainCamera.ScreenToWorldPoint(Input.mousePosition);
      private static bool    MainShootInput()   => Input.GetMouseButtonDown(0);
      private static bool    SecondShootInput() => Input.GetMouseButtonDown(1);
   }
}