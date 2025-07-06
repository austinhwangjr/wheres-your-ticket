using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using Unity.VisualScripting;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Button button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button.onClick.AddListener(GenerateTask);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(GenerateTask);
    }

    private void GenerateTask()
    {
        GameObject task = GameObject.Find("Generated Task");
        task.GetComponent<TextMeshProUGUI>().SetText("TASK GENERATED");
    }
}
