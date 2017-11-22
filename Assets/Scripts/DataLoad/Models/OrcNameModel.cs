using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;


[System.Serializable]
public class OrcNameModel 
{

   
    [SerializeField] private List<Dictionary<string, string>> fullDic;
    [SerializeField] private List<OrcName> orcNameList;

    public List<OrcName> OrcNameList
    {
        get
        {
            return orcNameList;
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

        TextAsset textAsset = (TextAsset)Resources.Load("XML/OrcNames");
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList itemList = xmlDoc.GetElementsByTagName("OrcNames");
       
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
                    case "OrcName":
                        partialDic.Add("OrcName", content.InnerText);
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

        orcNameList = new List<OrcName>();

        for (int i = 0; i < fullDic.Count; i++)
        {
            Dictionary<string, string> dic = fullDic[i];

            int ID = int.Parse(dic["ID"]);
            string name = dic["OrcName"];

            OrcName orcName = new OrcName(name);

            orcNameList.Add(orcName);
        }
        fullDic.Clear();
    }
    
}
