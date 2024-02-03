using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField]
    private float _force = 10f;
    
    [SerializeField]
    private GameObject _explosionPrefab;
    
    // Start is called before the first frame update
    
    void Start()
    {
        // Add a 2D force in the forward direction when this object is initialized 
        GetComponent<Rigidbody2D>().AddForce(transform.forward * _force, ForceMode2D.Impulse);
    }

    private void OnEnable()
    {
        // Spawn explosion after object is enabled
        Destroy(gameObject, 5f);
    }
    
    // Create a coroutine to spawn the explosion prefab after the current game object is destroyed
    private void OnDestroy()
    {
        if (_explosionPrefab == null) return;
        var explosionPrefab = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosionPrefab, 0.1f);
            
        //TODO: Create a scaling lerp animation
            
        // // Smoothly lerp using lerp function to explosion prefab scale from 0 to 1 over 0.5 seconds
        // explosionPrefab.transform.localScale = Vector3.zero;
        // LeanTween.scale(explosionPrefab, Vector3.one, 0.5f);




    }
}
