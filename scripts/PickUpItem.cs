using System;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
   private Transform player;
   [SerializeField] private float speed = 5f;
   [SerializeField] private float pickUpDistance = 1.5f;
   [SerializeField] private float ttl = 10f;

   private void Awake()
   {
      player = GameManager.instance.player.transform;
   }

   private void Update()
   {
      ttl -= Time.deltaTime;
      if (ttl < 0)
      {
         Destroy(gameObject);
      }

      float distance = Vector3.Distance(transform.position, player.position);
      if (distance > pickUpDistance)
      {
         return;
      }

      transform.position = Vector3.MoveTowards(
         transform.position,
          player.position, 
         speed * Time.deltaTime);
   }
} 
