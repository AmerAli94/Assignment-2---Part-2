// ===============================
// PROGRAM NAME: GAME Programming (T163)
// STUDENT ID : 101206769
// AUTHOR     : AMER ALI MOHAMMED
// CREATE DATE     : Nov 18, 2021
// PURPOSE     : GAME2014_F2021_ASSIGNMENT2_Part2
// SPECIAL NOTES:
// ===============================
// Change History:
// LOS for ground detection.
//==================================
//==================================
// Change History:
// 
//==================================


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
[System.Serializable]
public class LOS : MonoBehaviour
{
    [Header("Detection Properties")]
    public Collider2D collidesWith;
    public ContactFilter2D contactFilter;
    public List<Collider2D> colliderList;

    private PolygonCollider2D LOSCollider;

    // Start is called before the first frame update
    void Start()
    {
        LOSCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.GetContacts(LOSCollider, contactFilter, colliderList);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        collidesWith = other;
    }
}
