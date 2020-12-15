using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [Header("NPC資料")]
    public NPCData data;
    [Header("對話框")]
    public GameObject diaulog;
    [Header("對話內容")]
    public Text textContent;

    public bool PlayerInArea;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "角色") 
        {
            PlayerInArea = true;
            Dialog();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "角色") 
        {
            PlayerInArea = false;
        }
    }

    private void Dialog() 
    {
        //    for (int i = 0; i < 10; i++)
        //    {
        //        print("巴拉巴拉;"+i);
        //    }

        for (int i = 0; i < data.dialougA.Length; i++)
        {
            print(data.dialougA[i]);
        }
    }

    
}
