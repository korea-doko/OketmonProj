using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EAreaType
{
    Normal,
    Rainy,
    Cloudy,
    Lightening
}

public class AreaManager : MonoBehaviour {

    public AreaModel model;
    public AreaView view;

    private static AreaManager inst;

    public int numOfMaxArea;            // 최대 지형 숫자, 이것은 XML에서 가져옴, 지정불가
    public int numOfCurArea;            // 이건 숫자 정할 수 있음. 나중에 게임 난이도, 플레이 시간에 영향

    public int minNumOfSubArea;         // 서브 지형의 최소 갯수 
    public int maxNumOfSubArea;         // 서브 지형의 최대 갯수

    public int clickedAreaIndex;                // 선택한 area의 index
    public int clickedSubAreaIndex;             // 선택한 subArea Index
    public int clickedPlayerSelectPanelIndex;   // 플레이어가 선택한 Panel의 index
                                                
  
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
        view.OnSubAreaPlayerOrcPanelClicked += View_OnSubAreaPlayerOrcPanelClicked;
        view.OnSubAreaPlayerOrcSelectPanelClicked += View_OnSubAreaPlayerOrcSelectPanelClicked;
        view.OnSubAreaDetailPanelExcuteButtonClicked += View_OnSubAreaDetailPanelExcuteButtonClicked;
    }

    private void View_OnSubAreaDetailPanelExcuteButtonClicked(object sender, System.EventArgs e)
    {
        AreaData ad = model.AreaList[clickedAreaIndex];
        SubAreaData sad = ad.SubAreaList[clickedSubAreaIndex];

        //string str = "적\n";

        //foreach (OrcData od in sad.EnemyOrcList)
        //    str += od.GetTestInfo() + "\n";

        //str += "플레이어\n";
        //foreach(OrcData od in sad.PlayerOrcAry)
        //{
        //    if (od != null)
        //        str += od.GetTestInfo() + "\n";
        //}

        //Debug.Log(str);
        Debug.Log("여기서 해당 subArea의 상대방 몬스터와 플레이어 몬스터를 이용해서 적절한 계산을 통해 결과값을 도출해야한다.");

    }
    private void View_OnSubAreaPlayerOrcSelectPanelClicked(object sender, SubAreaPlayerOrcSelectPanelArgs e)
    {
        /*
         * 선택된 데이터를 area 데이터에 입력해야한다.         
         */

        List<OrcData> playerOrcList = PlayerManager.Inst.GetOrcDataList();

        OrcData selectedOrcData = playerOrcList[e.index];
        AreaData ad = model.AreaList[clickedAreaIndex];
        SubAreaData sad = ad.SubAreaList[clickedSubAreaIndex];

        sad.AddPlayerOrcData(clickedPlayerSelectPanelIndex,selectedOrcData);


        view.HideSubAreaPlayerOrcSelectPanel();
        view.ShowSubAreaDetailPanel(sad);
    }     
    private void View_OnAreaPanelClicked(object sender, AreaPanelClickedArgs e)
    {
        /*
         * Area를 닫고 subArea 보여줘야 한다. 
         */
        view.HideArea();

        clickedAreaIndex = e.clickedAreaPanelIndex;

        AreaData areaData = model.AreaList[clickedAreaIndex];

        view.ShowSubArea(areaData);        
    }
    private void View_OnSubAreaPanelClicked(object sender, SubAreaPanelClickedArgs e)
    {
        clickedSubAreaIndex = e.index;
        AreaData areaData = model.AreaList[clickedAreaIndex];
        SubAreaData subAreaData = areaData.SubAreaList[clickedSubAreaIndex];

        view.ShowSubAreaDetailPanel(subAreaData);        
    }
    private void View_OnSubAreaPlayerOrcPanelClicked(object sender, SubAreaPlayerOrcPanelArgs e)
    {
        clickedPlayerSelectPanelIndex = e.index;

        List<OrcData> playerOrcDataList = PlayerManager.Inst.GetOrcDataList();

        view.ShowSubAreaPlayerOrcSelectContainer(playerOrcDataList);
    }

    internal void ShowArea()
    {
        view.ShowArea(model);
    }
}

