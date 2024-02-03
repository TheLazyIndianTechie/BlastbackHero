using System;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField]
    private float _force = 10f;
    // Start is called before the first frame update
    
    void Start()
    {
        // Add a 2D force in the forward direction when this object is initialized 
        GetComponent<Rigidbody2D>().AddForce(transform.forward * _force, ForceMode2D.Impulse);
    }

    private void OnEnable() => Destroy(gameObject, 5f);
}
