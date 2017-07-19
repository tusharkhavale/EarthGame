using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EGameState
{
	Game,
	Globe
}

public enum ECountry
{
	Abhaziya,Afghanistan,Albania,Algeria,America,Angola,Antarctica,Argentina,Armenia,Australia,
	Austria,Azerbaijan,Bagamy,Bangladesh,Barbados,Belarus,Belgium,Belize,Benin,Bulgaria,Bolivia,
	Bosnia_and_Herzegovina,Botswana,Brazil,Britan,Brunei,Burundi,Burkina_Faso,Bhutan,Cameroon,
	Canada,Central_African_Republic,Chad,Czechia,Chernogoriya,Chile,Colombia,Greenland,DemocrRespKongo,
	Djibouti,Dominica,Dominican_Republic,Equatorial_Guinea,Ethiopia,Egypt,Ecuador,Eritrea,Estonia,
	Fiji,Philippines,Finland,FolklendskieOstrova,France,Gabon,Guyana,Gaiti,Gambiya,Ghana,Germany,
	Honduras,Greece,Grusiya,Guatemala,Guinea,Guinea_Bissau,Croatia,Yemen,India,Indonesia,Jordan,
	Iraq,Iran,Ireland,Iceland,Spain,Israel,Italy,Japan,Cabo_Verde,Cambodia,Qatar,Kazakhstan,Kenya,Kipr,
	Kyrgyzstan,China,Kodivuar,Congo,Costa_Rica,Cuba,Kuwait,Laos,Latvia,Lesotho,Liberia,Litva,Livan,Libiya,
	Luxembourg,Madagascar,Macedonia,Malaysia,Malawi,Mali,Malta,Morocco,Martinika,Mavrikii,Mavritaniya,
	Mexico,Moldova,Mongolia,Mozambique,Myanmar,Namibia,Nepal,Neytral,Neytral_2,Netherlands,Niger,Nigeria,
	Nicaragua,Norway,NovayaKaledonia,New_Zealand,UAE,Oman,Pakistan,Panama,Papua_New_Guinea,Paraguay,Peru,
	Poland,Portugal,PuertoRiko,Reynion,Russia,Rwanda,Romania,Salvador,Samoa,Saudi_Arabia,Senegal,Serbia,
	South_Korea,Sri_Lanka,Sierra_Leone,Syria,Slovakia,Slovenia,Solomon_Islands,Somalia,Sudan,Suriname,
	Swaziland,Swedan,Sweizariya,Tajikistan,Thailand,Taiwan,Tanzania,Togo,Trinidad_and_Tobago,Tunisia,
	Turkey,Turkmenistan,South_Africa,Uganda,Ukraine,Uruguay,Uzbekistan,UznayaKoreya,UznDjordjia,Vanuatu,Venezuela,
	Vengriya,Vietnam,Yamaika,YuzniySudan,Zambia,Zimbabwe,
}

public class Constants : MonoBehaviour {


	public static List<ECountry> lvl1 = new List<ECountry> ();
	public static List<ECountry> lvl2 = new List<ECountry> ();
	public static List<ECountry> lvl3 = new List<ECountry> ();
	public static List<ECountry> lvl4 = new List<ECountry> ();
	public static List<ECountry> lvl5 = new List<ECountry> ();
	public static List<ECountry> lvl6 = new List<ECountry> ();
	public static List<ECountry> lvl7 = new List<ECountry> ();
	public static List<ECountry> lvl8 = new List<ECountry> ();
	public static List<ECountry> lvl9 = new List<ECountry> ();
	public static List<ECountry> lvl10 = new List<ECountry> ();

	void Start()
	{
		lvl1.Add (ECountry.India);
		lvl1.Add (ECountry.China);
		lvl1.Add (ECountry.Russia);
		lvl1.Add (ECountry.America);
		lvl1.Add (ECountry.Canada);
		lvl1.Add (ECountry.Australia);
		lvl1.Add (ECountry.Antarctica);
		lvl1.Add (ECountry.Brazil);

		lvl2.Add (ECountry.Saudi_Arabia);
		lvl2.Add (ECountry.Pakistan);
		lvl2.Add (ECountry.Bangladesh);
		lvl2.Add (ECountry.Sri_Lanka);
		lvl3.Add (ECountry.Indonesia);
		lvl2.Add (ECountry.New_Zealand);
		lvl2.Add (ECountry.Mexico);
		lvl2.Add (ECountry.Argentina);
		lvl2.Add (ECountry.Germany);

		lvl3.Add (ECountry.Thailand);
		lvl3.Add (ECountry.Iran);
		lvl3.Add (ECountry.Libiya);
		lvl3.Add (ECountry.Malaysia);
		lvl3.Add (ECountry.Japan);
		lvl3.Add (ECountry.Norway);
		lvl3.Add (ECountry.Britan);
		lvl3.Add (ECountry.Philippines);

		lvl4.Add (ECountry.Spain);
		lvl4.Add (ECountry.Greenland);
		lvl4.Add (ECountry.South_Africa);
		lvl4.Add (ECountry.Madagascar);
		lvl4.Add (ECountry.Vietnam);
		lvl4.Add (ECountry.Chile);
		lvl4.Add (ECountry.France);

		lvl5.Add (ECountry.Cuba);
		lvl5.Add (ECountry.Venezuela);
		lvl5.Add (ECountry.Nigeria);
		lvl5.Add (ECountry.Yemen);
		lvl5.Add (ECountry.Afghanistan);
		lvl5.Add (ECountry.Nepal);
		lvl5.Add (ECountry.Papua_New_Guinea);
		lvl5.Add (ECountry.Egypt);
		lvl5.Add (ECountry.Namibia);
		lvl5.Add (ECountry.Madagascar);
		lvl5.Add (ECountry.Swedan);

		lvl6.Add (ECountry.Central_African_Republic);
		lvl6.Add (ECountry.Morocco);
		lvl6.Add (ECountry.Italy);
		lvl6.Add (ECountry.Iraq);
		lvl6.Add (ECountry.Finland);
		lvl6.Add (ECountry.Kazakhstan);
		lvl6.Add (ECountry.Myanmar);
		lvl6.Add (ECountry.Ukraine);
		lvl6.Add (ECountry.Colombia);
		lvl6.Add (ECountry.Dominican_Republic);
		lvl6.Add (ECountry.Ecuador);

		lvl7.Add (ECountry.Belarus);
		lvl7.Add (ECountry.Tanzania);
		lvl7.Add (ECountry.Mali);
		lvl7.Add (ECountry.Peru);
		lvl7.Add (ECountry.Iceland);
		lvl7.Add (ECountry.Mongolia);
		lvl7.Add (ECountry.Cambodia);
		lvl7.Add (ECountry.South_Korea);
		lvl7.Add (ECountry.Panama);
		lvl7.Add (ECountry.Ireland);
		lvl7.Add (ECountry.Turkey);
		lvl7.Add (ECountry.Poland);

		lvl8.Add (ECountry.Ukraine);
		lvl8.Add (ECountry.Somalia);
		lvl8.Add (ECountry.Oman);
		lvl8.Add (ECountry.Botswana);
		lvl8.Add (ECountry.Kenya);
		lvl8.Add (ECountry.Morocco);
		lvl8.Add (ECountry.Turkmenistan);
		lvl8.Add (ECountry.Algeria);
		lvl8.Add (ECountry.Angola);
		lvl8.Add (ECountry.Honduras);
		lvl8.Add (ECountry.Norway);
		lvl8.Add (ECountry.Uruguay);
		lvl8.Add (ECountry.Uzbekistan);

		lvl9.Add (ECountry.Syria);
		lvl9.Add (ECountry.Kyrgyzstan);
		lvl9.Add (ECountry.Bolivia);
		lvl9.Add (ECountry.Costa_Rica);
		lvl9.Add (ECountry.Laos);
		lvl9.Add (ECountry.Tajikistan);
		lvl9.Add (ECountry.Jordan);
		lvl9.Add (ECountry.Romania);
		lvl9.Add (ECountry.Portugal);
		lvl9.Add (ECountry.Guyana);
		lvl9.Add (ECountry.Nicaragua);
		lvl9.Add (ECountry.Paraguay);
		lvl9.Add (ECountry.Belgium);
		lvl9.Add (ECountry.Latvia);

		lvl10.Add (ECountry.Paraguay);
		lvl10.Add (ECountry.Guyana);
		lvl10.Add (ECountry.Guatemala);
		lvl10.Add (ECountry.Ethiopia);
		lvl10.Add (ECountry.Israel);
		lvl10.Add (ECountry.Latvia);
		lvl10.Add (ECountry.Albania);
		lvl10.Add (ECountry.Suriname);
		lvl10.Add (ECountry.Slovenia);
		lvl10.Add (ECountry.Netherlands);
		lvl10.Add (ECountry.Austria);
		lvl10.Add (ECountry.Croatia);
		lvl10.Add (ECountry.Bosnia_and_Herzegovina);


	}
}
