using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelector : MonoBehaviour
{
    public GameObject levelHolder;
    public GameObject levelIcon;
    public GameObject thisCanvas;
    private GameObject[] icons;
    public int numLevels = 3;
    private Rect panelDimensions;
    private Rect iconDimensions;
    private int currLevel;
    private AudioSource audioSrc;


    // Start is called before the first frame update
    void Start()
    {
        icons = new GameObject[numLevels];
        panelDimensions = levelHolder.GetComponent<RectTransform>().rect;
        iconDimensions = levelIcon.GetComponent<RectTransform>().rect;
        int maxinRow = Mathf.FloorToInt(panelDimensions.width / iconDimensions.width);
        int maxInCol = Mathf.FloorToInt(panelDimensions.height / iconDimensions.height);
        int amtinPage = maxInCol * maxinRow;
        int totalPages = Mathf.CeilToInt((float)numLevels / amtinPage);
        LoadPanels(totalPages);
    }

    private void LoadPanels(int pages)
    {
        GameObject panelClone = Instantiate(levelHolder) as GameObject;

        for (int i = 1; i <= pages; i++)
        {
            GameObject panel = Instantiate(panelClone) as GameObject;
            panel.transform.SetParent(thisCanvas.transform, false);
            panel.transform.SetParent(levelHolder.transform);
            panel.name = "Page " + i;
            panel.GetComponent<RectTransform>().localPosition = new Vector2(panelDimensions.width * (i - 1), 0);
            setUpGrid(panel);
            LoadIcons(numLevels, panel);
        }

        Destroy(panelClone);
    }

    private void LoadIcons(int numIcons, GameObject parentObject)
    {
        for (int i = 1; i <= numIcons; i++)
        {
            currLevel++;
            GameObject icon = Instantiate(levelIcon) as GameObject;
            icon.transform.SetParent(thisCanvas.transform, false);
            icon.transform.SetParent(parentObject.transform);
            icon.name = "Level " + i;
            icon.tag = "UI";
            icon.GetComponentInChildren<TextMeshProUGUI>().SetText("Level " + currLevel);
        
            icons[i - 1] = icon;
        }
    }

    private void OnMouseDown()
    {
        audioSrc = thisCanvas.GetComponent<AudioSource>();
        audioSrc.loop = false;
    }


    private void setUpGrid(GameObject panel)
    {
        GridLayoutGroup grid = panel.AddComponent<GridLayoutGroup>();
        grid.cellSize = new Vector2(200, 200);
        grid.spacing = new Vector2(500, 400);
        grid.childAlignment = TextAnchor.MiddleLeft;
        grid.startAxis = GridLayoutGroup.Axis.Vertical;
        grid.startCorner = GridLayoutGroup.Corner.UpperLeft;
        grid.constraint = GridLayoutGroup.Constraint.Flexible;

    }
    

    // Update is called once per frame
    void Update()
    {
     
    }
}
