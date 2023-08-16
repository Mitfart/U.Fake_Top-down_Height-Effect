using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Code {
   public class DropShadow : MonoBehaviour {
      private const string _SHADOW_NAME = "Shadow";

      public SpriteRenderer body;
      public Sprite         shadowSprite;
      public Vector2        offset;
      public Vector2        scale = Vector2.one;
      public bool           freezeRotation;

      [SerializeField, HideInInspector] private Transform      shadow;
      [SerializeField, HideInInspector] private SpriteRenderer shadowRender;

      private bool _shadowSpriteSet;



      private void Awake()  => SetupShadow();
      private void Update() => UpdateShadow();

      private void OnValidate() {
         if (body.IsUnityNull())
            return;

         if (body.transform.parent.IsUnityNull())
            throw new Exception("Not valid body for shadow! \n Body must have a parent game-object!");

         SetupShadow();
         UpdateShadow();
      }



      private void SetupShadow() {
         InitVariables();

         if (shadow.IsUnityNull())
            CreateShadow();

         UpdateShadow();
      }

      private void CreateShadow() {
         InsShadow();
         shadow.parent             = body.transform.parent;
         shadowRender.sortingOrder = body.sortingOrder - 1;
      }

      private void InitVariables() {
         _shadowSpriteSet = shadowSprite != null;
      }

      private void InsShadow() {
         shadow       = new GameObject(_SHADOW_NAME).transform;
         shadowRender = shadow.AddComponent<SpriteRenderer>();
      }


      private void UpdateShadow() {
         UpdateShadowRender();
         UpdateShadowTransform();
      }

      private void UpdateShadowRender() {
         if (_shadowSpriteSet)
            return;

         shadowRender.sprite = body.sprite;
         shadowRender.color  = body.color.ToShadow();
      }

      private void UpdateShadowTransform() {
         var inverseRot = Quaternion.Inverse(shadow.parent.rotation);

         shadow.localPosition = inverseRot * offset;
         shadow.localScale    = scale;

         if (freezeRotation)
            shadow.localRotation = inverseRot;
      }
   }
}