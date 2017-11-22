using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;


[System.Serializable]
public class AreaNameModel
{

    [SerializeField] private List<Dictionary<string, string>> fullDic;
    [SerializeField] private List<AreaName> areaNameList;

    public List<AreaName> AreaNameList
    {
        get
        {
            return areaNameList;
        }
    }

    public void Init()
    {
        ReadFromXML();
        MakeList();
    }
    private void ReadFromXML()
    {

        fullDic = new List<Dictionary<string, string>>();

        TextAsset textAsset = (TextAsset)Resources.Load("XML/AreaNames");
        
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList itemList = xmlDoc.GetElementsByTagName("AreaNames");

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
                    case "AreaName":
                        partialDic.Add("AreaName", content.InnerText);
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

        areaNameList = new List<AreaName>();

        for (int i = 0; i < fullDic.Count; i++)
        {
            Dictionary<string, string> dic = fullDic[i];

            int ID = int.Parse(dic["ID"]);
            string name = dic["AreaName"];

            AreaName areaName = new AreaName(name);

            areaNameList.Add(areaName);
        }
        fullDic.Clear();
    }

}
