using System;
using UnityEditor;
using UnityEngine;

public class CharacterInteractControler : MonoBehaviour
{
  private CharacterController2D characterController;
  Rigidbody2D rqdb2d;
  [SerializeField] private float offsetDistance = 1f;
  [SerializeField] private float sizeOfIntertableArea = 1.2f;
  private Character character;
  [SerializeReference] private HighlightController highlightController;

  private void Awake()
  {
      characterController = GetComponent<CharacterController2D>();
      rqdb2d = GetComponent<Rigidbody2D>();
      character = GetComponent<Character>();
  }

  private void Update()
  {
      Check();
      if (Input.GetMouseButtonDown(0))
      {
          Interact();
      } 
  }

  private void Check()
  {
      Vector2 position = rqdb2d.position + characterController.lastMotionVector * offsetDistance;

      Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfIntertableArea);

      foreach (Collider2D z in colliders)
      {
          Interactable hit = z.GetComponent<Interactable>();
          if (hit != null)
          {
              highlightController.Highlight(hit.gameObject);
              return;
          }
      } 
      highlightController.Hide();
  }

  private void Interact()
  {
      Vector2 position = rqdb2d.position + characterController.lastMotionVector * offsetDistance;

      Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfIntertableArea);

      foreach (Collider2D z in colliders)
      {
          Interactable hit = z.GetComponent<Interactable>();
          if (hit != null)
          {
              hit.Interact(character);
              break;
          }
      }
  }
}
