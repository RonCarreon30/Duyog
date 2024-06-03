using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XNode;
using UnityEngine.EventSystems;

public class NodeReader : MonoBehaviour
{
    public TMP_Text dialog;
    public Sprite backgroundImage;
    public GameObject ImageGO;
    public NodeGraph graph;
    public BaseNode currentNode;
    public GameObject CharacterSheet;

    public AudioSource audioSource;
    

    public TMPro.TMP_Text buttonAText;
    public TMPro.TMP_Text buttonBText;
    public GameObject buttonA;
    public GameObject buttonB;
    public GameObject nextButtonGO;

    void Start()
    {
        currentNode = GetStartNode();
        AdvanceDialog();
    }

    public BaseNode GetStartNode() 
    {
        return graph.nodes.Find(node => node is BaseNode && node.name == "Start") as BaseNode;
    }
    
    public void DisplayNode(BaseNode node)
    {
        dialog.text = node.getDialogText();
        backgroundImage = node.getSprite();
        ImageGO.gameObject.GetComponent<Image>().sprite = backgroundImage;

        AudioClip narrationAudio = node.GetNarrationAudio();
        // Play narration audio if available
        if (narrationAudio != null && audioSource != null)
        {
            audioSource.clip = narrationAudio;
            audioSource.Play();
        }

        if (node is SimpleDialog) // Check if node is a SimpleDialog node
        {
            buttonA.SetActive(false);
            buttonB.SetActive(false);
            nextButtonGO.SetActive(true);
        }
        else if (node is MultipleChoiceDialog)
        {
            buttonAText.text = "" + ((MultipleChoiceDialog)node).a;
            buttonBText.text = "" + ((MultipleChoiceDialog)node).b;
            
            buttonA.SetActive(true);
            buttonB.SetActive(true);
            nextButtonGO.SetActive(false);
        }
        else
        {
            buttonA.SetActive(false);
            buttonB.SetActive(false);
            nextButtonGO.SetActive(true);
        }
    }
    
    public void AdvanceDialog ()
    {
        var nextNode = GetNextNode(currentNode);
        if (nextNode != null)
        {
            currentNode = nextNode;
            DisplayNode(currentNode);
        }
        else
        {
            Debug.Log("nothing found");
        }
    }
    
    private BaseNode GetNextNode(BaseNode node) 
    {
        if (node is MultipleChoiceDialog)
        {
            GameObject clickedButton = EventSystem.current.currentSelectedGameObject;

            TMP_Text buttonText = clickedButton.GetComponentInChildren<TMP_Text>();

            if (buttonText.text == ("" + ((MultipleChoiceDialog)node).a)) 
            {
                return currentNode.GetOutputPort("a")?.Connection.node as BaseNode;
            }
            if (buttonText.text == ("" + ((MultipleChoiceDialog)node).b)) 
            {
                return currentNode.GetOutputPort("b")?.Connection.node as BaseNode;
            }

            return currentNode.GetOutputPort("exit")?.Connection.node as BaseNode;
        }
        else if (node is AbilityCheckNode abilityCheckNode) 
        {
            int d20 = Random.Range(0, 21);
            int characterStat = GetCharacterStat(abilityCheckNode.getAbility());
            Debug.Log("D20: " + d20);
            Debug.Log("Character Stats: " + characterStat);
            if ((d20 + characterStat) >= abilityCheckNode.getDC())
            {
                return currentNode.GetOutputPort("success")?.Connection.node as BaseNode;
            }
            else
            {
                return currentNode.GetOutputPort("fail")?.Connection.node as BaseNode;
            }
        }
        else
        {
            return currentNode.GetOutputPort("exit")?.Connection.node as BaseNode;
        }
    }

    private int GetCharacterStat(Ability ability)
    {
        CharStats charStats = CharacterSheet.gameObject.GetComponent<CharStats>();

        if (charStats == null)
        {
            Debug.LogError("CharStats component not found on CharacterSheet");
            return 0;
        }

        switch (ability)
        {
            case Ability.ARMORCLASS:
                return charStats.armorClass;
            case Ability.STRENGTH:
                return charStats.strength;
            case Ability.WISDOM:
                return charStats.wisdom;
            case Ability.CHARISMA:
                return charStats.charisma;
            case Ability.DEXTERITY:
                return charStats.dexterity;
            case Ability.CONSTITUTION:
                return charStats.constitution;
            case Ability.INTELLIGENCE:
                return charStats.intelligence;
            default:
                return 0; // Default case, should never happen if all abilities are covered
        }
    }
}
