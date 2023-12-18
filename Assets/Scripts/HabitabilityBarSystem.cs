using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HabitabilityBarSystem : MonoBehaviour
{
    // Variables
    public float habitability = 2f;
    public float growPeace=1f,damageByMeteor=15f,habitabilityChance=10f; // Game attributes,
    [SerializeField] Text habitabilityText;

    void Start(){
        habitability = 2; // Starting amount of habitability
        StartCoroutine(Reproduction()); 
        StartCoroutine(TimeToDeath());
    }

    void updateHabitabilityText(float amount){
        habitabilityText.text = amount.ToString();
    }

    // Habitability changing method
    public void updateHabitability(float amount){
        habitability += amount;
        updateHabitabilityText(habitability);
    }

    IEnumerator Reproduction(){
        // Variables
        int probabilityReproduction, waitForReproduction;

        while (true){
            probabilityReproduction = Random.Range(0, 100); // Generate a number for Reproduction probability
            waitForReproduction = Random.Range(20, 40);

            if (probabilityReproduction > 70)
                habitability += growPeace;
            else if (probabilityReproduction > 20)
                habitability += growPeace+2;
            else if (probabilityReproduction > 10)
                habitability += growPeace+3;

            updateHabitabilityText(habitability); // Update the habitability text

            yield return new WaitForSeconds(waitForReproduction); // Wait for reproduction again
        }
    }

    IEnumerator TimeToDeath(){
        // Variables
        int probabilityDeath, waitForDeath;
        if(habitability>150){
            while (true){
                probabilityDeath = Random.Range(0, 100); // Generate a number for Reproduction probability
                if(habitability<=250)
                    waitForDeath = Random.Range(15, 25);
                else
                    waitForDeath = Random.Range(5, 20);

                if (probabilityDeath > 90)
                    habitability -= 5;
                else if (probabilityDeath > 10)
                    habitability -= 10;

                updateHabitabilityText(habitability); // Update the habitability text

                yield return new WaitForSeconds(waitForDeath); // Wait for reproduction again
            }
        }
    }
}
