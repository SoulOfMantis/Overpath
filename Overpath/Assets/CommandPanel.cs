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
    public float height;
    public float Dif;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        height = gameObject.GetComponent<RectTransform>().rect.height;
        text.text = Algorithm.commandBlocks[BlockNumber].blockName;
        UpButton.onClick.AddListener(ButtonUp);
        DownButton.onClick.AddListener(ButtonDown);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void BlockUpdate(int dir)
    {
        (Algorithm.commandBlocks[BlockNumber], Algorithm.commandBlocks[BlockNumber + dir]) =
        (Algorithm.commandBlocks[BlockNumber+dir], Algorithm.commandBlocks[BlockNumber]);
        BlockNumber += dir;
        gameObject.transform.position = gameObject.transform.position + new Vector3(0, -dir*(Dif + height/100), 0);
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