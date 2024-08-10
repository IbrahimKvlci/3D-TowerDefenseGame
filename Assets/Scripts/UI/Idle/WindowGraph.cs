using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WindowGraph : MonoBehaviour
{
    [SerializeField] private TradeUI tradeUI;   
    [SerializeField] private Sprite circleSprite;
    [SerializeField] private RectTransform graphContainer;
    [SerializeField] private RectTransform labelXTemplate;
    [SerializeField] private RectTransform labelYTemplate;
    [SerializeField] private Image backgroundImg;
    [SerializeField] private Button rightBtn, leftBtn;

    

    private void Awake()
    {
        rightBtn.onClick.AddListener(() =>
        {
            ChangePage(true);
            UIAudioEffectController.Instance.PlayAudio(UIAudioEffectController.Instance.UISoundEffectsSO.openPanelound);

        });
        leftBtn.onClick.AddListener(() => { 
            ChangePage(false);
            UIAudioEffectController.Instance.PlayAudio(UIAudioEffectController.Instance.UISoundEffectsSO.openPanelound);

        });
    }

    private void Start()
    {
        int maxDay = 19;

        List<float> values = tradeUI.CurrentMineObjectTrader.PriceHistory.TakeLast(maxDay).ToList();
        int startingDay = 0;
        if (GameManager.Instance.Day - maxDay > 0)
            startingDay = GameManager.Instance.Day - maxDay;
        ShowGraph(values,startingDay,maxDay);
    }

    private GameObject CreateCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin= new Vector2(0,0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }

    private void ShowGraph(List<float> valueList,int startingDay,int endDay)
    {
        ClearGraph();

        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = 20f;
        if (valueList.Max()>yMaximum)
            yMaximum = valueList.Max();
   
        float xSize = 70f;

        GameObject lastCircleGameObject = null;
        for (int i = 0; i < valueList.Count; i++)
        {
            float xPosition=xSize+i*xSize;
            float yPosition = (valueList[i] / yMaximum) * graphHeight;
            GameObject circleGameObject= CreateCircle(new Vector2(xPosition,yPosition));
            if (lastCircleGameObject != null) { 
                CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition,circleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
            lastCircleGameObject = circleGameObject;
        }

        for (int i = 0; i < endDay; i++) 
        {
            float xPosition = xSize + i * xSize;
            RectTransform labelX = Instantiate(labelXTemplate);
            labelX.SetParent(graphContainer, false);
            labelX.gameObject.SetActive(true);
            labelX.anchoredPosition = new Vector2(xPosition, 0);
            labelX.GetComponent<TextMeshProUGUI>().text = $"{GameLanguageController.DayText} {startingDay+i + 1}";

            RectTransform labelY = Instantiate(labelYTemplate);
            labelY.SetParent(graphContainer,false);
            labelY.gameObject.SetActive(true);
            float normalizedValue = i * 1f / endDay;
            labelY.anchoredPosition=new Vector2(-7,normalizedValue*graphHeight);
            labelY.GetComponent<TextMeshProUGUI>().text=Mathf.RoundToInt(normalizedValue*yMaximum).ToString();
        }
    }

    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
    {
        GameObject gameObject=new GameObject("dotConnection",typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        RectTransform rectTransform=gameObject.GetComponent<RectTransform>();
        Vector2 dir=(dotPositionB- dotPositionA).normalized;
        float distance=Vector2.Distance(dotPositionA,dotPositionB);
        rectTransform.anchorMin = new Vector2(0,0);
        rectTransform.anchorMax = new Vector2(0,0) ;
        rectTransform.sizeDelta = new Vector2(distance,3);
        rectTransform.anchoredPosition=dotPositionA+dir*distance*.5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(dir));
    }

    private void ClearGraph()
    {
        foreach (Transform child in graphContainer.transform)
        {
            if (child == backgroundImg.transform || child == labelXTemplate.transform || child == labelYTemplate.transform)
            {
                continue;
            }
            Destroy(child.transform.gameObject);
        }
    }

    private void ChangePage(bool goRight)
    {
        int newIndex;

        if (goRight)
        {
            newIndex = tradeUI.MineObjectTraderList.IndexOf(tradeUI.CurrentMineObjectTrader) + 1;

            if(newIndex >= tradeUI.MineObjectTraderList.Count)
            {
                newIndex = 0;
            }
        }
        else
        {
            newIndex = tradeUI.MineObjectTraderList.IndexOf(tradeUI.CurrentMineObjectTrader) - 1;

            if (newIndex < 0)
            {
                newIndex = tradeUI.MineObjectTraderList.Count-1;
            }
        }

        tradeUI.CurrentMineObjectTrader = tradeUI.MineObjectTraderList[newIndex];

        int maxDay = 19;
        List<float> values = tradeUI.CurrentMineObjectTrader.PriceHistory.TakeLast(maxDay).ToList();
        int startingDay = 0;
        if (GameManager.Instance.Day - maxDay > 0)
            startingDay = GameManager.Instance.Day - maxDay;
        ShowGraph(values, startingDay, maxDay);

        tradeUI.ChangeCurrentMineObjectIcon(tradeUI.CurrentMineObjectTrader.MineObject.MineObjectSO.icon);
    }
}
