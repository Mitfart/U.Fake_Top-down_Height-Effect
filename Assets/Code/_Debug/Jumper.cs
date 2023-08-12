using UnityEngine;

namespace Code {
   public class Jumper : MonoBehaviour {
      public FakePhysics fakePhysics;
      public float       height;
      public float       duration;

      
      
      private void Update() {
         if (Input.GetKeyDown(KeyCode.Space))
            Jump();
      }

      private void Jump() {
         fakePhysics.Launch(
            Vector2.zero,
            height,
            0f,
            duration
         );
      }
   }
}