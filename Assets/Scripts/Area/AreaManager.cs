using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EAreaType
{

}


public class AreaManager : MonoBehaviour {

    public AreaModel model;
    public AreaView view;

    private static AreaManager inst;

    public int numOfMaxArea;            // 최대 지형 숫자, 이것은 XML에서 가져옴, 지정불가

    public int numOfCurArea;            // 이건 숫자 정할 수 있음. 나중에 게임 난이도, 플레이 시간에 영향

    public int minNumOfSubArea;         // 서브 지형의 최소 갯수 
    public int maxNumOfSubArea;         // 서브 지형의 최대 갯수

    public int clickedAreaIndex;
  
    public static AreaManager Inst
    {
        get
        {
            return inst;
        }
    }
    public AreaManager()
    {
        inst = this;
    }

    public void Start()
    {

        numOfMaxArea = DataLoadManager.Inst.GetAreaNameList().Count;

        numOfCurArea = UnityEngine.Random.Range(1, numOfMaxArea);

        minNumOfSubArea = 2;
        maxNumOfSubArea = 8;
        


        model.Init(numOfCurArea,minNumOfSubArea,maxNumOfSubArea);
        // 모델 초기화
  
        view.Init(numOfCurArea, maxNumOfSubArea);

        view.OnAreaPanelClicked += View_OnAreaPanelClicked;
        view.OnSubAreaPanelClicked += View_OnSubAreaPanelClicked;
    }

 
    public void ShowArea()
    {
        view.ShowArea(model);
    }
  
    /// <summary>
    /// Area를 닫고 subArea 보여줘야 한다.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void View_OnAreaPanelClicked(object sender, AreaPanelClickedArgs e)
    {
        view.HideArea();

        clickedAreaIndex = e.clickedAreaPanelIndex;

        AreaData areaData = model.AreaList[clickedAreaIndex];

        view.ShowSubArea(areaData);        
    }
    private void View_OnSubAreaPanelClicked(object sender, SubAreaPanelClickedArgs e)
    {
        AreaData areaData = model.AreaList[clickedAreaIndex];
        SubAreaData subAreaData = areaData.SubAreaList[e.index];

        view.ShowSubAreaDetailPanel(subAreaData);        
    }
}
