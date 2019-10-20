using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMotion : MonoBehaviour
{

    public Transform orbitObj;
    public Ellipse orbitPath;

    [Range(0f, 1f)]
    public float orbProg   = 0f;
    public float orbPeriod = 3f;
    public bool orbActive  = true;

    void Start()
    {
        orbitObj = gameObject.transform;
        SetPos();
        StartCoroutine(AnimateOrbit());
    }

    void SetPos()
    {
        Vector2 orbPos = orbitPath.Evaluate(orbProg);
        orbitObj.localPosition = new Vector3(orbPos.x, 0, orbPos.y);
    }

    IEnumerator AnimateOrbit()
    {
        float orbSpeed = 1f / orbPeriod;
        while (orbActive)
        {
            orbProg += Time.deltaTime * orbSpeed;
            orbPeriod %= 1f;
            SetPos();
            yield return null;
        }
    }

}
