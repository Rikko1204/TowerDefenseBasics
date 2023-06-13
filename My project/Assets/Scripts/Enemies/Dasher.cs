/*
 * The Dasher upon first taking damage
 * will dash forward a short distance
 * and become immune to damage while dashing.
 * CD: 10 seconds
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
            this.speed = 250f;
            damageMultiplier = 0;
            yield return new WaitForSeconds(seconds);
            this.speed = originalSpeed * 0.8f;
            yield return new WaitForSeconds(0.5f);
            damageMultiplier = 1;
        }

        public override void TakeDamage(float amount)
        {
            _health -= amount * damageMultiplier;
            healthBar.fillAmount = _health / maxHealth;
            if (_health <= 0)
            {
                //die
                Die();
            }
            if (_abilityReady)
            {
                StartCoroutine(Dash(0.4f));
                _abilityReady = false;
                countDown = timeBetweenAbility;
            }
        }
    }
}