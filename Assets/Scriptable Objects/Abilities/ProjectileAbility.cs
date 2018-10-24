using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability", menuName = "Abilities/Projectile")]
public class ProjectileAbility : Ability {

    // store prefabs here to allow skill the ability to instantiate them
    public GameObject projectilePrefab;

    public override void UseAbility(GameObject g) {
        var bullet = (GameObject)Instantiate(
            projectilePrefab,
            g.transform.position,
            g.transform.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 35;

        Destroy(bullet, 2.0f);
    }

}
