using System;
using UnityEngine;

public class ToolsCharacterController : MonoBehaviour
{
  CharacterController2D character;
  Rigidbody2D rqdb2d;
  [SerializeField] private float offsetDistance = 1f;
  [SerializeField] private float sizeOfIntertableArea = 1.2f;

  private void Awake()
  {
    character = GetComponent<CharacterController2D>();
    rqdb2d = GetComponent<Rigidbody2D>();
  }

  private void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      UseTool();
    } 
  }

  
  private void UseTool()
  {
    Vector2 position = rqdb2d.position + character.lastMotionVector * offsetDistance;

    Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfIntertableArea);

    foreach (Collider2D z in colliders)
    {
      ToolHit hit = z.GetComponent<ToolHit>();
      if (hit != null)
      {
        hit.Hit();
        break;
      }
    }
    {
      
    }
  }
}
