using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    private int _currentPage;
    private int _dividedLevelPerPage = 3;
    [SerializeField] private List<TextMeshProUGUI> _levelFields;
    private LevelLoader _levelLoader;
    private int _levelCount;
    [SerializeField] private Button _prevPageButton;
    [SerializeField] private Button _nextPageButton;
    void Start()
    {
        _levelLoader = GetComponent<LevelLoader>();
        _levelCount = _levelLoader.sceneCount;
        FillCurrentPage(0);

    }

    private void FillCurrentPage(int page)
    {
        if (page != 0)
        {
            _prevPageButton.gameObject.SetActive(true); 
        }
        else
        {
            _prevPageButton.gameObject.SetActive(false); 
        }

        if (page * _dividedLevelPerPage + _dividedLevelPerPage+1 > _levelCount)
        {
            _nextPageButton.gameObject.SetActive(false);
        }else _nextPageButton.gameObject.SetActive(true);


        int minInd = page * _dividedLevelPerPage;
        int maxInd = minInd + _dividedLevelPerPage ;
        if (maxInd > _levelCount-1)
        {
            maxInd = _levelCount-1;
        }

        int diff = maxInd - minInd;
        for (int i = 0; i <diff; i++)
        {
            _levelFields[i].text = _levelLoader.listOfLevels[minInd + i];
        }

        if (_dividedLevelPerPage - diff != 0)
        {
            int riz = _dividedLevelPerPage - diff;
            for (int i = _dividedLevelPerPage; _dividedLevelPerPage-riz < i ; i--)
            {
                _levelFields[i-1].text = "soon";
            }
        }

        _currentPage = page;
    }
    
    /*
      if (_dividedLevelPerPage - diff != 0)
        {
            int riz = _dividedLevelPerPage - diff;
            for (int i = _dividedLevelPerPage; 0 < i-riz ; i--)
            {
                _levelFields[i].text = "soon";
            }
        }
     */

    public void GetNextPage()
    {
        FillCurrentPage(_currentPage+1);
    }

    public void GetPrevPage()
    {
        FillCurrentPage(_currentPage-1);
    }
}
