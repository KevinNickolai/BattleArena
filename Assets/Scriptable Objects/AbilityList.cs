using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability List", menuName = "Ability List")]
public class AbilityList : ScriptableObject {

    [SerializeField]
    List<Ability> abilities = new List<Ability>();

    public Ability ReturnAbility(int i) {
        try {
            return abilities[i];
        } catch (System.IndexOutOfRangeException) {
            Debug.LogError("Ability index out of bounds @ " + this.name);
            return null;
        }
    }

}
