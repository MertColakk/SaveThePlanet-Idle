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
        StartCoroutine(Reproduction()); 
        StartCoroutine(TimeToDeath());
    }

    public void updateHabitabilityText(float amount){
        habitabilityText.text = amount.ToString();
    }

    // Habitability changing method
    public void changeHabitability(Collision other){
        if (other.gameObject.CompareTag("Meteor")){
            if (habitability > 2f)
                habitability -= 4;
            if (habitability <= 2)
                habitability = 2f;
        }
        else if (other.gameObject.CompareTag("CarbonStone"))
            habitability += 7f;
        

        updateHabitabilityText(habitability);
    }

    IEnumerator Reproduction(){
        // Variables
        int probabilityReproduction, waitForReproduction;

        while (true){
            probabilityReproduction = Random.Range(0, 100); // Generate a number for Reproduction probability
            waitForReproduction = Random.Range(20, 40);

            if (probabilityReproduction > 70)
                habitability += 1;
            else if (probabilityReproduction > 20)
                habitability += 2;
            else if (probabilityReproduction > 10)
                habitability += 3;

            updateHabitabilityText(habitability); // Update the habitability text

            yield return new WaitForSeconds(waitForReproduction); // Wait for reproduction again
        }
    }

    IEnumerator TimeToDeath(){
        // Variables
        int probabilityDeath, waitForDeath;

        while (true){
            probabilityDeath = Random.Range(0, 100); // Generate a number for Reproduction probability
            if(habitability<=100)
                waitForDeath = Random.Range(15, 25);
            else
                waitForDeath = Random.Range(5, 20);

            if (probabilityDeath > 90)
                habitability -= 1;
            else if (probabilityDeath > 10)
                habitability -= 3;

            updateHabitabilityText(habitability); // Update the habitability text

            yield return new WaitForSeconds(waitForDeath); // Wait for reproduction again
        }
    }
}
