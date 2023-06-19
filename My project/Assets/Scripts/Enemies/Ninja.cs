
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemies
{
    public class Ninja : Enemy
    {
        [Header("Go Invis Effect")]
        public GameObject smokeEffect;
        public Vector3 offSet;

        public GameObject reappearEffect;
        
        public override void UseAbility()
        {
            StartCoroutine(BecomeInvisible(3f));
        }

        IEnumerator BecomeInvisible(float seconds)
        {
            // Become "Invis" to towers
            String originalTag = tag;
            tag = "Player";
            
            // Become slightly faster
            var originalSpeed = this.speed;
            this.speed *= 1.25f;
            
            // Smoke your way through Orbital
            GameObject GO = Instantiate(smokeEffect, transform.position + offSet, transform.rotation);
            TrailingEffect smoke = GO.GetComponent<TrailingEffect>();
            smoke.Follow(transform, offSet);
            Destroy(GO, 3f);
            
            // Make the body slightly transparent ?? how ??
            
            yield return new WaitForSeconds(seconds);
            
            // Restore original attributes
            tag = originalTag;
            this.speed = originalSpeed;

            Instantiate(reappearEffect, transform.position, transform.rotation);
        }
    }
}