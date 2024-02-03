using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Create a player transform for a referene to the player
    public Transform player;
    
    // Create a reference to the grenade projectile object
    public GameObject grenade;

    [SerializeField] private float offset;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Create a method to spawn grenade when player hits the F key on the keyboard with an offset in the forward direction
        
            if (Input.GetKeyDown(KeyCode.F))
            {
                // Calculate the spawn position with an offset in the forward direction
                Vector3 spawnPosition = player.position + player.forward * offset;

                // Instantiate the grenade at the spawn position
                Instantiate(grenade, spawnPosition, Quaternion.identity);
            }
    }
}
