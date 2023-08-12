using UnityEngine;

namespace Code {
   public static class VectorRandomExt {
      public static float Random(this ref Vector2 vector2) 
         => UnityEngine.Random.Range(vector2.x, vector2.y);
      
      public static int Random(this ref Vector2Int vector2) 
         => UnityEngine.Random.Range(vector2.x, vector2.y);
   }
}