using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Create a player transform for a referene to the player
    public Transform player;
    
    // Create a reference to the grenade projectile object
    public GameObject grenade;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Create a method to spawn grenade when player hits the F key on the keyboard
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(grenade, player.position, player.rotation);
        }
        
    }
}
