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
        skills.Add(transform.GetChild(0).GetComponent<Skill>());
        skills.Add(transform.GetChild(1).GetComponent<Skill>());
        skills.Add(transform.GetChild(2).GetComponent<Skill>());
        skills.Add(transform.GetChild(3).GetComponent<Skill>());
        skills.Add(transform.GetChild(4).GetComponent<Skill>());
    }

    public static void spawnSkill(float playerdamge, Vector2 dir, Vector2 pos, Skill.skillType skilltype)
    {
        Skill s = Instantiate(getSkill(skilltype), pos, Quaternion.identity);
        s.setup(playerdamge, dir);
        s.StartCoroutine("DestroyWithAnimation");
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
