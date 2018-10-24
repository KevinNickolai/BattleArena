using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability")]
public abstract class Ability : ScriptableObject {

    public string aName = "Default Ability";
    public string aDescription = "Blank";
    public AudioClip aSound;
    public Sprite aSprite;

    public float aBaseCooldown = 1f;

    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility();

}
