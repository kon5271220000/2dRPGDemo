using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KusarigamaSkillController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private CircleCollider2D cd;
    private Player player;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<CircleCollider2D>();

    }

    public void SetUpKusarigama(Vector2 direction, float gravity)
    {
        rb.velocity = direction;
        rb.gravityScale = gravity;
    }
}
