using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class CharacterEvents
{
    //被造成伤害的角色和伤害数值
    public static UnityAction<GameObject, int> characterDamaged;

    //被治疗的角色和治疗数值
    public static UnityAction<GameObject, int> characterHealed;
}

