using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KusarigamaSkill : Skill
{
    [Header("Kusarigama skill variable")]
    [SerializeField] private GameObject kusarigamPrefab;
    [SerializeField] public Vector2 launchDirection;
    [SerializeField] public float kusarigamGravity;
    [SerializeField] private Transform LaunchPoint;

    public void CreateKusarigama()
    {
        GameObject newKusarigama = Instantiate(kusarigamPrefab, player.transform.position, transform.rotation);
        KusarigamaSkillController newKusarigamaScript = newKusarigama.GetComponent<KusarigamaSkillController>(); 

        //newKusarigamaScript.SetUpKusarigama(launchDirection, kusarigamGravity);
    }
}
