using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;


[System.Serializable]
public class AttackTypeModel
{
    [SerializeField] private List<Dictionary<string, string>> fullDic;
    [SerializeField] private List<AttackType> attackList;
    [SerializeField] private Dictionary<int, EAttackType> idDic;

    public List<AttackType> AttackList
    {
        get
        {
            return attackList;
        }
    }

    public void Init()
    {
        MakeIDDic();

        ReadFromXML();
        MakeList();
    }

    private void MakeIDDic()
    {
        idDic = new Dictionary<int, EAttackType>();

        TextAsset ta = (TextAsset)Resources.Load("XML/AttackType");
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(ta.text);
        XmlNodeList itemList = doc.GetElementsByTagName("AttackType");
        foreach (XmlNode itemInfo in itemList)
        {
            XmlNodeList itemContent = itemInfo.ChildNodes;
            int key = -1;
            int value = -1;

            foreach (XmlNode content in itemContent)
            {
                switch (content.Name)
                {
                    case "ID":
                        key = int.Parse(content.InnerText);
                        break;
                    case "GivenID":
                        value = int.Parse(content.InnerText);
                        break;
                    default:
                        break;
                }
            }
            idDic[key] = (EAttackType)value;
        }
    }
    private void ReadFromXML()
    {

        fullDic = new List<Dictionary<string, string>>();

        TextAsset textAsset = (TextAsset)Resources.Load("XML/Attack");
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList itemList = xmlDoc.GetElementsByTagName("Attack");

        foreach (XmlNode itemInfo in itemList)
        {
            XmlNodeList itemContent = itemInfo.ChildNodes;
            Dictionary<string, string> partialDic = new Dictionary<string, string>(); // ItemName is TestItem;

            foreach (XmlNode content in itemContent)
            {
                switch (content.Name)
                {
                    case "ID":
                        partialDic.Add("ID", content.InnerText);
                        break;
                    case "Type":
                        partialDic.Add("Type", content.InnerText);
                        break;
                    case "KoreanName":
                        partialDic.Add("KoreanName", content.InnerText);
                        break;
                    case "Desc":
                        partialDic.Add("Desc", content.InnerText);
                        break;
                    default:
                        break;
                }
            }

            fullDic.Add(partialDic);
        }


    }
    private void MakeList()
    {

        attackList = new List<AttackType>();

        for (int i = 0; i < fullDic.Count; i++)
        {
            Dictionary<string, string> dic = fullDic[i];

            int ID = int.Parse(dic["ID"]);

            int type = int.Parse(dic["Type"]);


            EAttackType etype = idDic[type];
            string koreanName = dic["KoreanName"];
            string desc = dic["Desc"];
            

            AttackType atkType = new AttackType(etype, koreanName, desc);
            attackList.Add(atkType);
        }
        fullDic.Clear();
        idDic.Clear();
    }

}
