using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;


[System.Serializable]
public class RankTypeModel
{
    [SerializeField] private List<Dictionary<string, string>> fullDic;
    [SerializeField] private List<RankType> rankList;
    [SerializeField] private Dictionary<int, ERank> idDic;

    public List<RankType> RankList
    {
        get
        {
            return rankList;
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
        idDic = new Dictionary<int, ERank>();

        TextAsset ta = (TextAsset)Resources.Load("XML/RankType");
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(ta.text);
        XmlNodeList itemList = doc.GetElementsByTagName("RankType");
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
            idDic[key] = (ERank)value;
        }
    }
    private void ReadFromXML()
    {

        fullDic = new List<Dictionary<string, string>>();

        TextAsset textAsset = (TextAsset)Resources.Load("XML/Rank");
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList itemList = xmlDoc.GetElementsByTagName("Rank");

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

        rankList = new List<RankType>();

        for (int i = 0; i < fullDic.Count; i++)
        {
            Dictionary<string, string> dic = fullDic[i];

            int ID = int.Parse(dic["ID"]);

            int type = int.Parse(dic["Type"]);


            ERank etype = idDic[type];

            string koreanName = dic["KoreanName"];
            string desc = dic["Desc"];


            RankType rankType= new RankType(etype, koreanName, desc);
            rankList.Add(rankType);
        }
        fullDic.Clear();
        idDic.Clear();
    }
}
