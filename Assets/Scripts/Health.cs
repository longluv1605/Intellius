using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{   
    public static Health Instance {get; private set;}
    public float maxHealth = 100f; 
    public float currentHealth = 100f; 
    private float totalTime = 6f; 
    
    private float healthDecreaseRate; 

    public Image healthImage; 

    private void Start()
    {
        Instance = this;
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

            if (currentHealth <= maxHealth * 2/3 && currentHealth >= maxHealth * 1/3) 
            {
                healthImage.color = Color.yellow;
            }
            else
            {
                if (currentHealth <= maxHealth * 1/3)
                {
                    healthImage.color = Color.red;
                }
            }
        }
        SceneManager.LoadScene(3);
    }
}