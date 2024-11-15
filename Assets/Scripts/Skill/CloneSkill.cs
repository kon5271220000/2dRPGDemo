using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSkill : MonoBehaviour
{
    [SerializeField] private GameObject clonePrefabs;
    [SerializeField] private float closeCloneDuration;
    [SerializeField] private bool canAttack;

    public void CreateClone(Transform clonePosition)
    {
        GameObject newClone = Instantiate(clonePrefabs);

        newClone.GetComponent<CloneSkillManager>().SetUpClone(clonePosition, closeCloneDuration, canAttack);

    }
}
