using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;


[System.Serializable]
public class ClassTypeModel
{
    [SerializeField] private List<Dictionary<string, string>> fullDic;
    [SerializeField] private List<ClassType> classList;
    [SerializeField] private Dictionary<int, EClassType> idDic;

    public List<ClassType> ClassList
    {
        get
        {
            return classList;
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
        idDic = new Dictionary<int, EClassType>();

        TextAsset ta = (TextAsset)Resources.Load("XML/ClassType");
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(ta.text);
       
        XmlNodeList itemList = doc.GetElementsByTagName("ClassType");
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
            idDic[key] = (EClassType)value;
        }
    }
    private void ReadFromXML()
    {

        fullDic = new List<Dictionary<string, string>>();

        TextAsset textAsset = (TextAsset)Resources.Load("XML/Class");
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        
        XmlNodeList itemList = xmlDoc.GetElementsByTagName("Class");

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

        classList = new List<ClassType>();

        for (int i = 0; i < fullDic.Count; i++)
        {
            Dictionary<string, string> dic = fullDic[i];

            int ID = int.Parse(dic["ID"]);

            int type = int.Parse(dic["Type"]);



            EClassType etype = idDic[type];

            string koreanName = dic["KoreanName"];
            string desc = dic["Desc"];


            ClassType classType= new ClassType(etype, koreanName, desc);
            classList.Add(classType);
        }
        fullDic.Clear();
        idDic.Clear();
    }
}
