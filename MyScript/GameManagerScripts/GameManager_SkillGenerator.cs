using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_SkillGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public SkillInfo generate_skill()
    {
        SkillInfo skill = new SkillInfo();

        SkillInfo.Skill_Type type = (SkillInfo.Skill_Type)Random.Range(0, SkillInfo.Pasnum);

        float value = (float)Random.Range(100, 1000) / 100.0f;

        skill.skillType = type;
        skill.value = value;
        return skill;
    }
}
