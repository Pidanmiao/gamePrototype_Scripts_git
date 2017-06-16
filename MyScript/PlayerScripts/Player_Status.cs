using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Status : MonoBehaviour {
    [System.Serializable]
    public struct Status_Modify
    {
        public float heal_mod;
        public float eng_mod;
        public float move_mod;
        public float dmg_mod;
        public float speed_mod;
        public float ammo_mod;
        public float charge_mod;
        public float armor_mod;
        public float armorrate_mod;
        public float accr_mod;
    }
    Guninfo[] gunList = new Guninfo[4];
    SkillInfo[] posSkillList = new SkillInfo[10];
    SkillInfo[] actSkillList = new SkillInfo[3];
    Guninfo currentgun;
    int currentgun_num;
    int ammo_used;
    int ammonum;
    public Status_Modify modifies;
    Player_AmmoBox ammobox;
    // Use this for initialization
    void Start () {
        actSkillList[0].skillType = SkillInfo.Skill_Type.Act_Deadattack;
        actSkillList[0].value = 0;
        actSkillList[1].skillType = SkillInfo.Skill_Type.Act_Recovery;
        actSkillList[1].value = 0;
        actSkillList[2].skillType = SkillInfo.Skill_Type.Act_Firetime;
        actSkillList[2].value = 0;
        currentgun_num = 0;
        ammobox = GetComponent<Player_AmmoBox>();
        caculateall();
    }

    // Update is called once per frame
    void Update () {
		
	}
    private void caculateall()
    {
        Player_Health health = GetComponent<Player_Health>();
        health.maxHealth = (int)(100 * (1 + modifies.heal_mod));
        currentgun.guntype = gunList[currentgun_num].guntype;
        currentgun.damage = gunList[currentgun_num].damage * (1 + modifies.dmg_mod);
        currentgun.accuracy = gunList[currentgun_num].accuracy * (1 + modifies.accr_mod);
        currentgun.shotspeed = gunList[currentgun_num].shotspeed * (1 + modifies.speed_mod);
        currentgun.rechargespeed = gunList[currentgun_num].rechargespeed * (1 + modifies.charge_mod);
        currentgun.maxAmmo = (int)(gunList[currentgun_num].maxAmmo * (1 + modifies.ammo_mod));
        //movement
    }
    void getammo()
    {
        if (ammobox.typesOfAmmunition.Count == 0) return;
        if (ammobox.typesOfAmmunition.Count <= ammo_used) ammo_used = 0;
        int acquire = currentgun.maxAmmo - ammonum;
        if (acquire == 0) return;
        if (ammobox.typesOfAmmunition[ammo_used].ammoCurrentCarried < acquire) acquire = ammobox.typesOfAmmunition[ammo_used].ammoCurrentCarried;
        if (acquire == 0)
        {
            if (ammonum == 0)
            {
                ammobox.typesOfAmmunition.RemoveAt(ammo_used);
                getammo();
                
            }
            return;
        }
        ammonum += acquire;
        ammobox.typesOfAmmunition[ammo_used].ammoCurrentCarried -= acquire;

    }

    void returnammo()
    {
        ammobox.typesOfAmmunition[ammo_used].ammoCurrentCarried += ammonum;
        ammonum = 0;
    }
    public void negative_skill_entry(SkillInfo skill)
    {
        switch (skill.skillType)
        {
            case SkillInfo.Skill_Type.Pas_accr:
                modifies.accr_mod += skill.value;
                break;
            case SkillInfo.Skill_Type.Pas_charge:
                modifies.charge_mod += skill.value;
                actSkillList[2].value += skill.value/2;
                break;
            case SkillInfo.Skill_Type.Pas_dmg:
                modifies.dmg_mod += skill.value;
                break;
            case SkillInfo.Skill_Type.Pas_health:
                modifies.heal_mod += skill.value;
                break;
            case SkillInfo.Skill_Type.Pas_move:
                modifies.move_mod += skill.value;
                break;
            case SkillInfo.Skill_Type.Pas_speed:
                modifies.speed_mod += skill.value;
                actSkillList[2].value += skill.value/2;
                break;

            default:
                break;

        }
        caculateall();
    }

    public void negative_skill_exit(SkillInfo skill)
    {
        switch (skill.skillType)
        {
            case SkillInfo.Skill_Type.Pas_accr:
                modifies.accr_mod -= skill.value;
                return;
            case SkillInfo.Skill_Type.Pas_charge:
                modifies.charge_mod -= skill.value;
                actSkillList[2].value -= skill.value/2;
                return;
            case SkillInfo.Skill_Type.Pas_dmg:
                modifies.dmg_mod -= skill.value;
                return;
            case SkillInfo.Skill_Type.Pas_health:
                modifies.heal_mod -= skill.value;
                return;
            case SkillInfo.Skill_Type.Pas_move:
                modifies.move_mod -= skill.value;
                return;
            case SkillInfo.Skill_Type.Pas_speed:
                modifies.speed_mod -= skill.value;
                actSkillList[2].value -= skill.value/2;
                return;

            default:
                return;
        }
    }
}
