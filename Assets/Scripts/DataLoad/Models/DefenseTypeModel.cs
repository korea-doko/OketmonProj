using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;



[System.Serializable]
public class DefenseTypeModel
{
    [SerializeField] private List<Dictionary<string, string>> fullDic;
    [SerializeField] private List<DefenseType> defenseList;
    [SerializeField] private Dictionary<int, EDefenseType> idDic;

    public List<DefenseType> DefenseList
    {
        get
        {
            return defenseList;
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
        idDic = new Dictionary<int, EDefenseType>();

        TextAsset ta = (TextAsset)Resources.Load("XML/DefenseType");
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(ta.text);
        XmlNodeList itemList = doc.GetElementsByTagName("DefenseType");
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
            idDic[key] = (EDefenseType)value;
        }
    }
    private void ReadFromXML()
    {

        fullDic = new List<Dictionary<string, string>>();

        TextAsset textAsset = (TextAsset)Resources.Load("XML/Defense");
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList itemList = xmlDoc.GetElementsByTagName("Defense");

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

        defenseList = new List<DefenseType>();

        for (int i = 0; i < fullDic.Count; i++)
        {
            Dictionary<string, string> dic = fullDic[i];

            int ID = int.Parse(dic["ID"]);

            int type = int.Parse(dic["Type"]);


            EDefenseType etype = idDic[type];
            string koreanName = dic["KoreanName"];
            string desc = dic["Desc"];


            DefenseType defType= new DefenseType(etype, koreanName, desc);
            defenseList.Add(defType);
        }
        fullDic.Clear();
        idDic.Clear();
    }

}
