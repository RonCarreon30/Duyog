using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    // Variables to store character's stats
    public int healthPoints;
    public string characterName; // Fixed typo here
    public int armorClass;
    public int strength;
    public int wisdom;
    public int charisma; 
    public int dexterity;
    public int constitution;
    public int intelligence;

    // Start is called before the first frame update
    void Start()
    {
        // Retrieve selected character's stats from PlayerPrefs
        healthPoints = PlayerPrefs.GetInt("SelectedCharacterHealthPoints");
        characterName = PlayerPrefs.GetString("SelectedCharacterName");
        armorClass = PlayerPrefs.GetInt("SelectedCharacterArmorClass");
        strength = PlayerPrefs.GetInt("SelectedCharacterStrength");
        wisdom = PlayerPrefs.GetInt("SelectedCharacterWisdom");
        charisma = PlayerPrefs.GetInt("SelectedCharacterCharisma");
        dexterity = PlayerPrefs.GetInt("SelectedCharacterDexterity");
        constitution = PlayerPrefs.GetInt("SelectedCharacterConstitution");
        intelligence = PlayerPrefs.GetInt("SelectedCharacterIntelligence");

        // Now you can use the character's stats as needed
        Debug.Log("Health Points: " + healthPoints);
        Debug.Log("Character Name: " + characterName);
        Debug.Log("Armor Class: " + armorClass);
        Debug.Log("Strength: " + strength);
        Debug.Log("Wisdom: " + wisdom);
        Debug.Log("Charisma: " + charisma);
        Debug.Log("Dexterity: " + dexterity);
        Debug.Log("Constitution: " + constitution);
        Debug.Log("Intelligence: " + intelligence);
    }
}
