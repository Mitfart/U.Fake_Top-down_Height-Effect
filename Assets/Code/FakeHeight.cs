using UnityEngine;

namespace Code {
   public class FakeHeight : MonoBehaviour {
      public Transform body;

      [SerializeField] private float height;

      public float Height {
         get => height;
         set {
            height = Mathf.Max(0f, value);
            UpdateBody();
         }
      }



      private void Update() => UpdateBody();


      private void UpdateBody() => body.localPosition = WorldUp() * Height;

      private Vector3 WorldUp() => Quaternion.Inverse(body.rotation) * Vector3.up;
   }
}