using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Code {
   public class DropShadow : MonoBehaviour {
      private const string _SHADOW_NAME = "Shadow";

      public SpriteRenderer body;

      public SpriteRenderer Shadow { get; private set; }



      private void Awake()  => CreateShadow();
      private void Update() => UpdateShadow();

      private void OnValidate() {
         if (!body.IsUnityNull() && body.transform.parent.IsUnityNull())
            Debug.LogWarning("Not valid body for shadow! \n Body must have a parent game-object!");
      }



      private void CreateShadow() {
         InsShadow();
         SetShadowTransform();
         UpdateShadow();
      }

      private void SetShadowTransform() {
         Transform shadowT = Shadow.transform;
         Transform bodyT   = body.transform;

         shadowT.parent        = bodyT.parent;
         shadowT.localPosition = bodyT.localPosition;
         shadowT.localRotation = bodyT.localRotation;
         shadowT.localScale    = bodyT.localScale;
      }

      private void UpdateShadow() {
         UpdateShadowRender();
      }

      private void UpdateShadowRender() {
         Shadow.sortingOrder = body.sortingOrder - 1;
         Shadow.sprite       = body.sprite;
         Shadow.color        = body.color.ToShadow();
      }

      private void InsShadow() => Shadow = new GameObject(_SHADOW_NAME).AddComponent<SpriteRenderer>();
   }
}