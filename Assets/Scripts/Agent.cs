using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
	private AgentName _agentName;
	private AgentAttribute _agentAttribute;
	private Gender _gender;
	//private Ability _ability;
	private Grade _grade;
	private Rarity _rarity;
	private Labo _labo;

	public Agent(AgentName agentName)
	{
		_agentName = agentName;
		getAgentPropaty(_agentName);
	}

	private void getAgentPropaty(AgentName agentName)
	{
		switch (agentName)
		{
			case AgentName.SPEAKER:
				_agentAttribute = AgentAttribute.SECRET;
				_gender = Gender.MALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.TANK:
				_agentAttribute = AgentAttribute.SECRET;
				_gender = Gender.MALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.OBLIQUESHADOW:
				_agentAttribute = AgentAttribute.SECRET;
				_gender = Gender.FEMALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.TITANIUM:
				_agentAttribute = AgentAttribute.SECRET;
				_gender = Gender.MALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.LARKLADY:
				_agentAttribute = AgentAttribute.SECRET;
				_gender = Gender.FEMALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.SWANMAIDEN:
				_agentAttribute = AgentAttribute.SECRET;
				_gender = Gender.FEMALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.HUNTRESS:
				_agentAttribute = AgentAttribute.SECRET;
				_gender = Gender.FEMALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.BLACKHAND:
				_agentAttribute = AgentAttribute.SECRET;
				_gender = Gender.MALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.NIGHTMARE:
				_agentAttribute = AgentAttribute.SECRET;
				_gender = Gender.FEMALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.BARONBRUMAIRE:
				_agentAttribute = AgentAttribute.SECRET;
				_gender = Gender.MALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.MARKJUNIOR:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.MALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.STATICELECTRICITY:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.FEMALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.VIPER:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.MALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.ANGEL:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.FEMALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.SAVAGEASSASSIN:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.MALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.DOUBLEKNIGHT:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.MALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.KWONKIKU:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.MALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.DARKFLOW:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.MALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.DIAMONDMAN:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.MALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.PERFUME:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.FEMALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.TOUGHGUN:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.MALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.REDBLADE:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.MALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.ALIAS:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.FEMALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.BACKFIRE:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.MALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.TRINITY:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.FEMALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.J:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.MALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
			case AgentName.DETECTIVE:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.MALE;
				_grade = Grade.NONE;
				_rarity = Rarity.NORMAL;
				_labo = Labo.NONE;
				break;
				
			/* オリジナルエージェント */
			case AgentName.CHAINER:
				_agentAttribute = AgentAttribute.SECRET;
				_gender = Gender.MALE;
				_grade = Grade.Y17;
				_rarity = Rarity.RARE;
				_labo = Labo.KURO;
				break;
			case AgentName.PSYCHOPATH:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.MALE;
				_grade = Grade.Y17;
				_rarity = Rarity.SUPER;
				_labo = Labo.HORY;
				break;
			case AgentName.GOLDHEAD:
				_agentAttribute = AgentAttribute.SECRET;
				_gender = Gender.MALE;
				_grade = Grade.Y16;
				_rarity = Rarity.RARE;
				_labo = Labo.HORY;
				break;
			case AgentName.NEUTRAL:
				_agentAttribute = AgentAttribute.SECRET;
				_gender = Gender.MALE;
				_grade = Grade.Y17;
				_rarity = Rarity.SUPER;
				_labo = Labo.KURO;
				break;
			case AgentName.GAMEMASTER:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.NONE;
				_grade = Grade.Y17;
				_rarity = Rarity.RARE;
				_labo = Labo.KURO;
				break;
			case AgentName.DUELIST:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.FEMALE;
				_grade = Grade.Y17;
				_rarity = Rarity.SUPER;
				_labo = Labo.HORY;
				break;
			case AgentName.HANDSTANDER:
				_agentAttribute = AgentAttribute.SECRET;
				_gender = Gender.MALE;
				_grade = Grade.Y17;
				_rarity = Rarity.RARE;
				_labo = Labo.KURO;
				break;
			case AgentName.SMALLSPACE:
				_agentAttribute = AgentAttribute.SECRET;
				_gender = Gender.FEMALE;
				_grade = Grade.Y17;
				_rarity = Rarity.SUPER;
				_labo = Labo.HORY;
				break;
			case AgentName.FILLER:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.MALE;
				_grade = Grade.Y17;
				_rarity = Rarity.RARE;
				_labo = Labo.KURO;
				break;
			case AgentName.MOMENTSLEEP:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.MALE;
				_grade = Grade.Y17;
				_rarity = Rarity.RARE;
				_labo = Labo.HORY;
				break;
			case AgentName.VITARITYRECORDER:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.MALE;
				_grade = Grade.Y15;
				_rarity = Rarity.SUPER;
				_labo = Labo.KURO;
				break;
			case AgentName.CHAIRMAN:
				_agentAttribute = AgentAttribute.SECRET;
				_gender = Gender.MALE;
				_grade = Grade.Y15;
				_rarity = Rarity.SUPER;
				_labo = Labo.KURO;
				break;
			case AgentName.AMNESIA:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.MALE;
				_grade = Grade.Y15;
				_rarity = Rarity.RARE;
				_labo = Labo.HORY;
				break;
			case AgentName.TIPSY:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.MALE;
				_grade = Grade.Y15;
				_rarity = Rarity.RARE;
				_labo = Labo.KURO;
				break;
			case AgentName.PEPPER:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.NONE;
				_grade = Grade.NONE;
				_rarity = Rarity.SUPER;
				_labo = Labo.KURO;
				break;
			case AgentName.JUGGLER:
				_agentAttribute = AgentAttribute.PUBLIC;
				_gender = Gender.MALE;
				_grade = Grade.Y16;
				_rarity = Rarity.RARE;
				_labo = Labo.HORY;
				break;
			case AgentName.KUROSAWASENSEI:
				_agentAttribute = AgentAttribute.PUBLIC;
				_gender = Gender.MALE;
				_grade = Grade.PROF;
				_rarity = Rarity.ULTRA;
				_labo = Labo.KURO;
				break;
			case AgentName.LIFEGAMER:
				_agentAttribute = AgentAttribute.SECRET;
				_gender = Gender.MALE;
				_grade = Grade.Y15;
				_rarity = Rarity.SUPER;
				_labo = Labo.KURO;
				break;
			case AgentName.SUNFLOWER:
				_agentAttribute = AgentAttribute.SECRET;
				_gender = Gender.MALE;
				_grade = Grade.Y16;
				_rarity = Rarity.SUPER;
				_labo = Labo.KURO;
				break;
			case AgentName.FISHCAKE:
				_agentAttribute = AgentAttribute.SECRET;
				_gender = Gender.NONE;
				_grade = Grade.Y16;
				_rarity = Rarity.SUPER;
				_labo = Labo.KURO;
				break;
			case AgentName.HOST:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.MALE;
				_grade = Grade.Y15;
				_rarity = Rarity.RARE;
				_labo = Labo.HORY;
				break;
			case AgentName.MORPHEUS:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.MALE;
				_grade = Grade.Y15;
				_rarity = Rarity.SUPER;
				_labo = Labo.HORY;
				break;
			case AgentName.TRUMPETER:
				_agentAttribute = AgentAttribute.SECRET;
				_gender = Gender.MALE;
				_grade = Grade.Y16;
				_rarity = Rarity.RARE;
				_labo = Labo.KURO;
				break;
			case AgentName.KEYBOARDER:
				_agentAttribute = AgentAttribute.SECRET;
				_gender = Gender.FEMALE;
				_grade = Grade.Y16;
				_rarity = Rarity.RARE;
				_labo = Labo.HORY;
				break;
			case AgentName.JULIUS:
				_agentAttribute = AgentAttribute.SECRET;
				_gender = Gender.MALE;
				_grade = Grade.PROF;
				_rarity = Rarity.ULTRA;
				_labo = Labo.KURO;
				break;
			case AgentName.FONTJUNKIE:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.MALE;
				_grade = Grade.Y15;
				_rarity = Rarity.RARE;
				_labo = Labo.KURO;
				break;
			case AgentName.SPRINCAR:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.MALE;
				_grade = Grade.PROF;
				_rarity = Rarity.ULTRA;
				_labo = Labo.HORY;
				break;
			case AgentName.BLACKPEPPER:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.NONE;
				_grade = Grade.NONE;
				_rarity = Rarity.SUPER;
				_labo = Labo.KURO;
				break;
			case AgentName.SHELLKEAPER:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.FEMALE;
				_grade = Grade.Y15;
				_rarity = Rarity.RARE;
				_labo = Labo.KURO;
				break;
			case AgentName.IPHONE:
				_agentAttribute = AgentAttribute.SECRET;
				_gender = Gender.MALE;
				_grade = Grade.Y17;
				_rarity = Rarity.SUPER;
				_labo = Labo.KURO;
				break;
			case AgentName.SUNSHINE:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.MALE;
				_grade = Grade.Y17;
				_rarity = Rarity.ULTRA;
				_labo = Labo.KURO;
				break;
			case AgentName.PANDAPEPPER:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.NONE;
				_grade = Grade.NONE;
				_rarity = Rarity.SUPER;
				_labo = Labo.NONE;
				break;
			case AgentName.TAKAYATSU:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.MALE;
				_grade = Grade.Y17;
				_rarity = Rarity.SUPER;
				_labo = Labo.KURO;
				break;
			case AgentName.RAMEN:
				_agentAttribute = AgentAttribute.NORMAL;
				_gender = Gender.NONE;
				_grade = Grade.NONE;
				_rarity = Rarity.ULTRA;
				_labo = Labo.NONE;
				break;
				
		}
	}



	public AgentName getAgentName()
	{
		return _agentName;
	}

	public void useAbility(AgentName agentName)
    {
        // GameObserver.Instance.
    }
	
}
