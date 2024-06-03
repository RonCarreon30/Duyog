using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class TripleChoice : BaseNode {

	[Input] public string entry;
	[Output] public string a;
	[Output] public string b;
	[Output] public string c;

	[TextArea(7,20)]
	public string dialogText;
	public Sprite dialogImage;
	public AudioClip narrationAudio; // Add AudioClip field for narration audio

	public override string getDialogText() {
		return dialogText;
	}

	public override Sprite getSprite() {
		return dialogImage;
	}

	public override AudioClip GetNarrationAudio() {
        return narrationAudio;
    }
}