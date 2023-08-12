using UnityEngine;
using Random = UnityEngine.Random;

namespace Code {
   public class Splash : MonoBehaviour {
      [Header("Launch")] //
      public Vector2 distance;
      public Vector2 height;
      public Vector2 duration;

      [Header("Scale")] //
      public Vector2 markScale;
      public Vector2 particleScale;
      public Vector2 particleRotation;

      [Header("Spawn")] //
      public GameObject[] marks;
      public FakePhysics[] particles;
      public Vector2       spawnRadius;
      public Vector2Int    amount;

      public Vector2 velocity;
      public bool    playOnStart;



      private void Start() {
         if (playOnStart)
            Play();
      }

      public void Play() {
         Transform parent = transform;

         if (HasMarks())
            CreateMark(parent);

         SpawnParticles(parent);
      }

      private void OnDrawGizmosSelected() {
         Vector3 origin = transform.position;

         Gizmos.color = Color.grey;
         Gizmos.DrawWireSphere(origin, distance.x + spawnRadius.x);
         Gizmos.DrawWireSphere(origin, distance.y + spawnRadius.y);

         Gizmos.color = Color.cyan;
         Gizmos.DrawWireSphere(origin, distance.x);
         Gizmos.DrawWireSphere(origin, distance.y);

         Gizmos.color = Color.green;
         Gizmos.DrawWireSphere(origin, spawnRadius.x);
         Gizmos.DrawWireSphere(origin, spawnRadius.y);

         Gizmos.color = Color.yellow;
         Gizmos.DrawWireCube(
            origin + Vector3.up * (height.y + height.x) * .5f,
            new Vector3(1f, height.y        - height.x)
         );
      }



      private void SpawnParticles(Transform parent) {
         int particlesAmount = amount.Random();

         for (var i = 0; i < particlesAmount; i++) {
            Instantiate(
                  particles.Random(),
                  parent.position + (Vector3)Random.insideUnitCircle.normalized * spawnRadius.Random(),
                  parent.rotation * Quaternion.Euler(ZAxis() * particleRotation.Random()),
                  parent
               )
              .Scale(particleScale.Random())
              .Launch(
                  Random.insideUnitCircle + velocity.normalized,
                  height.Random(),
                  distance.Random(),
                  duration.Random()
               );
         }
      }

      private void CreateMark(Transform parent) {
         Instantiate(
               marks.Random(),
               parent.position,
               parent.rotation,
               parent
            )
           .Scale(markScale.Random());
      }



      private bool HasMarks() => marks.Length > 0;

      private static Vector3 ZAxis() => Vector3.forward;
   }
}