/*
 * The Healer is an enemy that performs single target heals on other enemies periodically.
 * It is unable to heal itself but other Healers can still heal this
 */

using UnityEngine;

namespace Enemies
{
    public class Healer : Enemy, IHasAbility
    {
        public GameObject healingEffectPrefab;
        public float HealAmount;
    
        [Header("For Centering Heal Effect")]
        public Vector3 offSet;
    
        public override void UseAbility()
        {
            // Search for the nearest OTHER tagged Enemy and restore health
            Vector3 pos = transform.position;
            float dist = float.PositiveInfinity;
            ChaseableEntity targ = null;
            foreach (var healable in ChaseableEntity.Entities)
            {
                var targetDist = (pos - healable.transform.position).sqrMagnitude;
                if (targetDist < dist && targetDist > 0.2f) // closest Enemy which is not this.
                {
                    targ = healable;
                    dist = targetDist;
                }
            }
        
            // The Effect
            try
            {
                targ.GetComponent<Enemy>().TakeDamage(-HealAmount);
            }
            catch (System.NullReferenceException e)
            {
                return;
            }

            // Particle System 
            var transform1 = targ.transform;
            GameObject GO = Instantiate(healingEffectPrefab,
                transform1.position + offSet,
                transform1.rotation);

            TrailingEffect healingEffect = GO.GetComponent<TrailingEffect>();

            if (healingEffect != null)
            {
                healingEffect.Follow(targ.transform, offSet);
            }
        }
    }
}

