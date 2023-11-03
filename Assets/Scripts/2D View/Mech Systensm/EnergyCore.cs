using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnergyCore : MonoBehaviour
{
    [Header("Attributes")] 
    [SerializeField] private float energyLevel;
    [SerializeField] private float energyDrain;
    [SerializeField] private float energyRefillAmount;
    private int maxEnergy;
    
    [Header("Settings")] 
    [SerializeField] private float coolDownBetweenEnergyDrain;

    private bool once = true;
    [SerializeField] private float scoreNoEnergy;
    
    [Header("Refs")] 
    [SerializeField] GroundButton buttonFillEnergy;
    [SerializeField] GroundButton buttonEjectShell;
    [SerializeField] protected ResourceHoldingPlace console;
    [SerializeField] private TMP_Text text; 
    [SerializeField] private TMP_Text text2; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        maxEnergy = (int)energyLevel;
        StartCoroutine(DrainEnergy());
    }

    // Update is called once per frame
    void Update()
    {   
        if(energyLevel==0)
        {
            if (once)
            {
                once = false;
                SoundManager.Play(3);
            }
            GameMaster.ChangeScoreBy(scoreNoEnergy);
        }

        if (energyLevel >= 0 && !once)
        {
            SoundManager.Stop(3);
            once = true;
        }
        if (buttonFillEnergy.buttonWasPressed)
        {
            buttonFillEnergy.buttonWasPressed = false;
            RefilEnergy();
        }
        else if (buttonEjectShell.buttonWasPressed)
        {
            buttonFillEnergy.buttonWasPressed = false;
            EjectShell();
        }

        CheckEnergyLevel();
        UpdateSprite();
        UpdateText();
    }

    private void RefilEnergy()
    {
        if (!console.isLoaded)
        {
            Debug.Log("Refill although empty");
            //TODO bad action 
            return;
        }

        if (console.DepleteResource())
        {
        energyLevel += energyRefillAmount;
        if (energyLevel >= maxEnergy) energyLevel = maxEnergy;
        Debug.Log("Energy Refilled");
        }
        else
        {
            Debug.Log("Refill but no energy in");
        }
    }

    private void EjectShell()
    {
        if (!console.isLoaded)
        {
            //TODO bad action
            return;
        }
        console.EjectShell();
        Debug.Log("Shell ejceted");

    }
    
    protected IEnumerator DrainEnergy()
    {
        while (true)
        {
            yield return new WaitForSeconds(coolDownBetweenEnergyDrain);
            if (energyLevel - energyDrain > 0) energyLevel -= energyDrain;
            else energyLevel = 0;
        }
        
    }

    private void CheckEnergyLevel()
    {
        //TODO do stuff when energy empty etc.
    }

    private void UpdateSprite()
    {
        //TODO this
    }
    /**
     * Chcks if enough energy is leved for draining.
     */
    public bool CheckIfEnoughEnergyForDrainThenDrain(float amountEnergy)
    {
        bool enoughEnergy = false;
        if (energyLevel - amountEnergy > 0)
        {
            energyLevel -= amountEnergy;
            enoughEnergy = true;
        }

        return enoughEnergy;
    }

    private void UpdateText()
    {
        text.SetText("Energy: " +((int)energyLevel).ToString() + "/" + maxEnergy.ToString());
        text2.SetText("Energy: " +((int)energyLevel).ToString() + "/" + maxEnergy.ToString());

    }
    
}