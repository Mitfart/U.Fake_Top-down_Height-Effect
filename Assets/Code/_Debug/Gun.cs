using UnityEngine;

namespace Code {
   public class Gun : MonoBehaviour {
      private const string _CONTAINER_NAME = "[ Projectiles ]";

      public Transform shootOrigin;

      private Transform _container;



      private void Start() {
         _container = new GameObject(_CONTAINER_NAME).transform;
      }

      public void Shoot(
         float       startHeight,
         FakePhysics projectile,
         float       height,
         float       distance,
         float       duration
      ) {
         FakePhysics projectileIns = Instantiate(
            projectile,
            shootOrigin.position - Vector3.up * startHeight,
            shootOrigin.rotation,
            _container
         );
         projectileIns.fakeHeight.Height = startHeight;
         projectileIns.Launch(
            transform.right,
            height + startHeight,
            distance,
            duration
         );
      }
   }
}