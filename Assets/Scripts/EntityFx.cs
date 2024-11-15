using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFx : MonoBehaviour
{
    private SpriteRenderer sr;

    [Header("Flash Fx")]
    [SerializeField] private Material hitMat;
    private Material originMat;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        originMat = sr.material;
    }

    private IEnumerator FlashFx()
    {
        sr.material = hitMat;

        yield return new WaitForSeconds(0.2f);

        sr.material = originMat;
    }

    private void RedColorBlink()
    {
        if (sr.color != Color.white)
        {
            sr.color = Color.white;
        }
        else
        {
            sr.color = Color.red;
        }

    }

    private void CanceleRedBlink()
    {
        CancelInvoke();
        sr.color = Color.white;
    }
}
