using UnityEngine;

namespace Code {
   public class ShrinkShadowByHeight : MonoBehaviour {
      public                 FakeHeight fakeHeight;
      public                 DropShadow dropShadow;
      public                 float      disappearHeight;
      [Range(0f, 1f)] public float      minScale;

      private float _dividedDisappearHeight;


      private void Start()  => InitVariables();
      private void Update() => SetShadowScale();



      private void InitVariables() => _dividedDisappearHeight = 1f / disappearHeight;

      private void SetShadowScale() => dropShadow.scale = Vector3.one * Mathf.Max(minScale, CalcScale());

      private float CalcScale() => 1f - Mathf.Clamp01(fakeHeight.Height * _dividedDisappearHeight);
   }
}