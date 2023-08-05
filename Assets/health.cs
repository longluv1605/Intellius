using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public float totalTime = 600f; 
    
    private float healthDecreaseRate; 

    public Image healthImage; 

    private void Start()
    {
        healthImage.fillAmount = 1f; 

        healthDecreaseRate = maxHealth / totalTime; 
        
        StartCoroutine(DecreaseHealthOverTime());
    }

    private IEnumerator DecreaseHealthOverTime()
    {
        while (currentHealth > 0)
        {
            currentHealth -= healthDecreaseRate * Time.deltaTime;
            healthImage.fillAmount = currentHealth / maxHealth;

            yield return null;
        }
    }
}