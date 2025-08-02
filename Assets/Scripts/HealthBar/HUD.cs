using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    [SerializeField] private Slider healthbar;
    private void SetupHealthbar(GameObject player){
        
    }
    private void OnEnable(){
        GameController.OnPlayerSpawned+= SetupHealthbar;
        PlayerHealth.OnPlayerTakeDamage+=UpdateHealthbar;
    }

    private void OnDisable(){
        GameController.OnPlayerSpawned-= SetupHealthbar;
        PlayerHealth.OnPlayerTakeDamage-=UpdateHealthbar;
    }
}
