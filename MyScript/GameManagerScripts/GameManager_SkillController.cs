using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_SkillController : MonoBehaviour {

    public Player_Status status;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void positive_skill_execute(SkillInfo skill)
    {
        switch (skill.skillType)
        {
            case SkillInfo.Skill_Type.Act_Deadattack:
                return;
            case SkillInfo.Skill_Type.Act_Firetime:
                return;
            case SkillInfo.Skill_Type.Act_Recovery:
                return;
            default:
                return;
        }
    }
}
