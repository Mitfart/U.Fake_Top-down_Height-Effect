using UnityEngine;

namespace Code {
   public class Mover : MonoBehaviour {
      public float speed;


      private void Update() => Move();

      private void Move() => transform.Translate(InputDirection() * (speed * Time.deltaTime));

      private static Vector2 InputDirection() {
         var input = new Vector2( //
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
         );
         input.Normalize();
         return input;
      }
   }
}