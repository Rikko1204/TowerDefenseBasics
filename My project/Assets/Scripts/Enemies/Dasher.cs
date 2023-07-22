/*
 * The Dasher upon first taking damage
 * will dash forward a short distance
 * and become immune to damage while dashing (and a brief moment after dashing).
 * CD: 10 seconds (adjustable)
 * (The first instance of damage still happens)
 */

using System.Collections;
using UnityEngine;

namespace Enemies
{
    public class Dasher : Enemy
    {
        private bool _abilityReady = false;

        public override void UseAbility()
        {
            _abilityReady = true;
        }

        IEnumerator Dash(float seconds)
        {
            float originalSpeed = this.speed;
            this.speed = 150f;
            damageMultiplier = 0;
            yield return new WaitForSeconds(seconds);
            this.speed = originalSpeed * 0.9f;
            yield return new WaitForSeconds(0.2f);
            damageMultiplier = 1;
        }

        public override void TakeDamage(float amount)
        {
            Health -= amount * damageMultiplier;
            healthBar.fillAmount = Health / maxHealth;
            if (_abilityReady)
            {
                StartCoroutine(Dash(0.4f));
                _abilityReady = false;
                countDown = timeBetweenAbility;
            }
        }
    }
}