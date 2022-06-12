using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public List<Skill> skills;

    public static SkillController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        skills = new List<Skill>();
    }

    public static void spawnSkill(float playerdamge, Vector2 dir, Vector2 pos, Skill.skillType skilltype)
    {
        Skill w = Instantiate(getSkill(skilltype), pos, Quaternion.identity);
        w.setup(playerdamge, dir);
    }

    public static Skill getSkill(Skill.skillType skilltype)
    {
        return Instance.skills.Find(x => x.skilltype == skilltype);
    }

    public static List<Skill> getSkillList()
    {
        return Instance.skills;
    }
}
