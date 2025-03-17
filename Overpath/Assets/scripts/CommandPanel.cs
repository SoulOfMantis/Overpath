using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CommandPanel : MonoBehaviour
{
    public AlgorithmController Algorithm;
    public TextMeshProUGUI text;
    public Button UpButton;
    public Button DownButton;
    public int BlockNumber;
    public float gap = 10f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var rectTransform = GetComponent<RectTransform>();
        text.text = Algorithm.commandBlocks[BlockNumber].blockName;
        UpButton.onClick.AddListener(ButtonUp);
        DownButton.onClick.AddListener(ButtonDown);
        UpdatePanelPositions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void BlockUpdate(int dir)
    {
        int newIndex = BlockNumber + dir;
        Algorithm.SwapBlocksAndPanels(BlockNumber, newIndex);

        UpdatePanelPositions();
    }
    void UpdatePanelPositions()
    {
        float currentY = 0f;
        for (int i = 0; i < Algorithm.commandPanels.Length; i++)
        {
            RectTransform panelRect = Algorithm.commandPanels[i].GetComponent<RectTransform>();
            panelRect.anchoredPosition = new Vector2(panelRect.anchoredPosition.x, -currentY);
            currentY += panelRect.rect.height/2 + gap;
        }
    }
    void ButtonUp()
    {
        if (BlockNumber > 0)
            BlockUpdate(-1);
    }
    void ButtonDown()
    {
        if (BlockNumber < Algorithm.commandBlocks.Length)
            if (BlockNumber != Algorithm.commandBlocks.Length-1)
                BlockUpdate(1);
    }
    
}