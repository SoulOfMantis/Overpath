using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NestedPanel : MonoBehaviour
{
    public InternalBlock motherBlock;
    public TextMeshProUGUI text;
    public Button UpButton;
    public Button DownButton;
    public int BlockNumber;
    public float gap = 10f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var rectTransform = GetComponent<RectTransform>();
        text.text = motherBlock.nestedBlocks[BlockNumber].blockName;
        UpButton.onClick.AddListener(ButtonUp);
        DownButton.onClick.AddListener(ButtonDown);
        UpdatePanelPositions();
    }

    void BlockUpdate(int dir)
    {
        int newIndex = BlockNumber + dir;
        motherBlock.SwapNestedBlocksAndPanels(BlockNumber, newIndex);

        UpdatePanelPositions();
    }
    void UpdatePanelPositions()
    {
        float currentY = 0f;
        for (int i = 0; i < motherBlock.nestedPanels.Length; i++)
        {
            RectTransform panelRect = motherBlock.nestedPanels[i].GetComponent<RectTransform>();
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
        if (BlockNumber < motherBlock.nestedBlocks.Length)
            if (BlockNumber != motherBlock.nestedBlocks.Length-1)
                BlockUpdate(1);
    }
    
}