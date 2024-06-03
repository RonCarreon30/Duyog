using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectScript : MonoBehaviour
{
    [System.Serializable]
    public class Character
    {
        public Sprite characterImage;
        public string characterName;
        public int healthPoints;
        public int armorClass;
        public int strength;
        public int wisdom;
        public int charisma;
        public int dexterity;
        public int constitution;
        public int intelligence;
    }

    public Character[] characters = new Character[3]; // Array for three characters
    private int currentIndex = 0;

    public Image characterImageUI;
    public Button nextButton;
    public Button previousButton;
    public Button selectButton;


 // Background Music
    public AudioSource backgroundMusicAudioSource;
    public float startTime = 6f; // Time to start the audio at (in seconds)


    void Start()
    {
        UpdateCharacterUI();
        nextButton.onClick.AddListener(NextCharacter);
        previousButton.onClick.AddListener(PreviousCharacter);
        selectButton.onClick.AddListener(SelectCharacter);

        // Play background music and set starting time
        if (backgroundMusicAudioSource != null && !backgroundMusicAudioSource.isPlaying)
        {
            backgroundMusicAudioSource.time = startTime; // Set the starting time
            backgroundMusicAudioSource.Play();
        }
    }

    void NextCharacter()
    {
        currentIndex = (currentIndex + 1) % characters.Length;
        UpdateCharacterUI();
    }

    void PreviousCharacter()
    {
        currentIndex = (currentIndex - 1 + characters.Length) % characters.Length;
        UpdateCharacterUI();
    }

    void UpdateCharacterUI()
    {
        characterImageUI.sprite = characters[currentIndex].characterImage;
    }

    void SelectCharacter()
    {
        //get the stats of the character based on the index since nakaarray yung list ng characters ko
        Character selectedCharacter = characters[currentIndex];

        //Set the actual data into the player prefs which can be passed and use to the other scene
        PlayerPrefs.SetString("SelectedCharacterName", selectedCharacter.characterName);
        PlayerPrefs.SetInt("SelectedCharacterHealthPoints", selectedCharacter.healthPoints);
        PlayerPrefs.SetInt("SelectedCharacterArmorClass", selectedCharacter.armorClass);
        PlayerPrefs.SetInt("SelectedCharacterStrength", selectedCharacter.strength);
        PlayerPrefs.SetInt("SelectedCharacterWisdom", selectedCharacter.wisdom);
        PlayerPrefs.SetInt("SelectedCharacterCharisma", selectedCharacter.charisma);
        PlayerPrefs.SetInt("SelectedCharacterDexterity", selectedCharacter.dexterity);
        PlayerPrefs.SetInt("SelectedCharacterConstitution", selectedCharacter.constitution);
        PlayerPrefs.SetInt("SelectedCharacterIntelligence", selectedCharacter.intelligence);
        //Load the next scene
        SceneManager.LoadScene("SampleScene");
    }
}