using UnityEngine;

public static class Rotate2DExt {
   private static Vector3 ZAxis => Vector3.forward;



   public static Transform Rotate2D(this Transform transform, float by) {
      transform
        .Rotate(
            ZAxis,
            by
         );
      return transform;
   }

   public static GameObject Rotate2D(this GameObject go, float by) {
      go.transform.Rotate2D(by);
      return go;
   }

   public static TComp Rotate2D<TComp>(this TComp comp, float by) where TComp : Component {
      comp.transform.Rotate2D(by);
      return comp;
   }



   public static Transform Rotate2D(this Transform transform, Vector3 at) {
      transform.rotation = transform.Rotation(at);
      return transform;
   }

   public static GameObject Rotate2D(this GameObject go, Vector3 at) {
      go.transform.Rotate2D(at);
      return go;
   }

   public static TComp Rotate2D<TComp>(this TComp comp, Vector3 at) where TComp : Component {
      comp.transform.Rotate2D(at);
      return comp;
   }



   private static Quaternion Rotation(this  Transform transform, Vector3 at) => Quaternion.AngleAxis(AngleOf(transform.RotateDir(at)), ZAxis);
   private static Vector3    RotateDir(this Transform transform, Vector3 at) => at - transform.position;
   private static float      AngleOf(Vector3          vector) => Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
}