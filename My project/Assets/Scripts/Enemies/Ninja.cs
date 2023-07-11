using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

/*
 * The ninja is able to camo itself to prevent detection by towers
 * It should not be targeted by towers during it's invisibility.
 * Standard Invis Time: 3s
 * Standard Cooldown: 5s -> 2s of time for towers to target this
 */

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