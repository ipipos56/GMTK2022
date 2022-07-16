using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] private int health;
   [SerializeField] private float speed;

   private void Update()
   {
      if (health <= 0)
      {
         Destroy(gameObject);
      }
      transform.Translate(Vector2.left * (speed * Time.deltaTime));
   }

   public void TakeDamage(int damage)
   {
      health -= damage;
   }
}
