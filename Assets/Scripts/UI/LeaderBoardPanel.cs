using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardPanel : MonoBehaviour
{

    [SerializeField]
    private GameObject resultViewPrefab;

    [SerializeField]
    private Transform resultsKeeper;

    private int prefabsAmount;

    private void OnEnable()
    {
        prefabsAmount = SaveRecordList.SavedDatas.Count;
        for (int i = 0; i < prefabsAmount; i++)
        {
            var tmp = Instantiate(resultViewPrefab, resultsKeeper);
            tmp.GetComponent<Text>().text = SaveRecordList.SavedDatas[i].ToString();
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < prefabsAmount; i++)
        {
            Destroy(resultsKeeper.GetChild(i).gameObject);
        }
    }
}

