using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
    [Header("NPC資料")]
    public NPCData data;
    [Header("對話框")]
    public GameObject diaulog;
    [Header("對話內容")]
    public Text textContent;
    [Header("對話名稱")]
    public Text textname;
    [Header("對話間隔")]
    public float interval = 0.2f;

    public bool PlayerInArea;

    //private void Start()
    //{
    // StartCoroutine(Dialog());
    //}
    // private IEnumerator test() 
    //{
    //  print("我");
    //yield return new WaitForSeconds(1.5f);
    //print("是");
    //}

    public enum NPCState 
    {
        FirstDialog,Missioning,Finish
    }
    public NPCState state = NPCState.FirstDialog;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "角色") 
        {
            PlayerInArea = true;
            StartCoroutine(Dialog());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "角色") 
        {
            PlayerInArea = false;
            StopDialog();
        }
    }

    private void StopDialog() 
    {
        diaulog.SetActive(false);
        StopAllCoroutines();
    }
    private IEnumerator Dialog() 
    {
        //    for (int i = 0; i < 10; i++)
        //    {
        //        print("巴拉巴拉;"+i);
        //    }
        diaulog.SetActive(true);
        textContent.text = "";
        textname.text = name;

        string dialogString = data.dialougB;

        switch (state)
        {
            case NPCState.FirstDialog:
                dialogString = data.dialougA;
                break;
            case NPCState.Missioning:
                dialogString = data.dialougB;
                break;
            case NPCState.Finish:
                dialogString = data.dialougC;
                break;
        }

        for (int i = 0; i < dialogString.Length; i++)
        {
            //print(data.dialougA[i]);
            textContent.text += dialogString[i] + "";
            yield return new WaitForSeconds(interval);
        }
    }

    
}
