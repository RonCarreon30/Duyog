using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class BaseNode : Node {

    public virtual string getDialogText()
    {
        return "";
    }

    public virtual Sprite getSprite()
    {
        return null;
    }

	public virtual Ability getAbility()
	{
		return Ability.CHARISMA;
	}

	public virtual float getDC()
	{
		return 10.0f;
	}
	
	public virtual AudioClip GetNarrationAudio() {
        return null;
    }
}