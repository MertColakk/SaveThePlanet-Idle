using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HabitabilityBarSystem : MonoBehaviour
{
    // Variables
    float habitability = 2f; // Game attribute
    [SerializeField] Text habitabilityText;

    void Start(){
        habitability = 2; // Starting amount of habitability
        
        StartCoroutine(Reproduction(habitability)); // Starting habitability
    }

    public void updateHabitabilityText(float amount){
        habitabilityText.text = amount.ToString();
    }

    // Habitability changing method
    public void changeHabitability(Collision other){
        if (other.gameObject.CompareTag("Meteor"))
            habitability = (habitability > 1f) ? habitability - 4 : 1f;
        else if (other.gameObject.CompareTag("CarbonStone"))
            habitability += 4f;
        
        updateHabitabilityText(habitability);
    }

    public IEnumerator Reproduction(float habitabilityAmount){
        // Variables
        int probabilityReproduction, waitForReproduction;

        while (true){
            probabilityReproduction = Random.Range(0, 100); // Generate a number for Reproduction probability
            waitForReproduction = Random.Range(10, 25); // Generate a number for Wait second

            habitabilityAmount += (probabilityReproduction > 70) ? 1 : (probabilityReproduction > 20) ? 2 : (probabilityReproduction > 10) ? 3 : 0;

            updateHabitabilityText(habitabilityAmount); // Update the habitability text

            yield return new WaitForSeconds(waitForReproduction); // Wait for reproduction again
        }
    }

    public IEnumerator TimeOfDeath(float habitabilityAmount){
        // Variables
        int probabilityDeath, waitForReproduction;

        while (true){
            probabilityDeath = Random.Range(0, 100); // Generate a number for Reproduction probability
            
            waitForReproduction = (habitability <= 40) ? Random.Range(30, 45) : Random.Range(20, 35);

            habitabilityAmount -= (probabilityDeath>95)?3 :(probabilityDeath>5)?1:0;

            updateHabitabilityText(habitabilityAmount); // Update the habitability text

            yield return new WaitForSeconds(waitForReproduction); // Wait for reproduction again
        }
    }
}
