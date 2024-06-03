using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class AbilityCheckNode : BaseNode {

	[Input] public string entry;
	[Output] public string success;
	[Output] public string fail;

	[TextArea(7,20)]
	public string dialogText;
	public Sprite dialogImage;
	public AudioClip narrationAudio; // Add AudioClip field for narration audio
	public float difficultyCheckValue;
	public Ability AbilityCheck;

	public override string getDialogText() {
		return dialogText;
	}

	public override Sprite getSprite() {
		return dialogImage;
	}

	public override Ability getAbility()
	{
		return AbilityCheck;
	}
	
	public override float getDC()
	{
		return difficultyCheckValue;
	}
	
	public override AudioClip GetNarrationAudio() {
        return narrationAudio;
    }
}