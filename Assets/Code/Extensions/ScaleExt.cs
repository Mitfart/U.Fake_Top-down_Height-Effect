using UnityEngine;

namespace Code {
   public static class ScaleExt {
      public static Transform Scale(this Transform transform, float value) {
         transform.localScale = Vector3.one * value;
         return transform;
      }

      public static Transform Scale(this GameObject go, float value) => go.transform.Scale(value);

      public static TComp Scale<TComp>(this TComp component, float value) where TComp : Component {
         component.transform.Scale(value);
         return component;
      }
   }
}