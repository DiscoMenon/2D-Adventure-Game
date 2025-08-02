using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Jump playerMovement;
    public GameObject gameOverScreen; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GetComponent<Jump>().enabled = false;
            gameOverScreen.SetActive(true); 
        }
    }
}
