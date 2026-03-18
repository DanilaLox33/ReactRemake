using System;
using System.Collections.Generic;
using Project.Features.DialogSystem;
using Project.Features.Person;
using UnityEngine;

[CreateAssetMenu(fileName = "ChooseSystem", menuName = "ChooseSystem")]
public class ChooseSystem : ScriptableObject
{
    private ChoosePanel view;

    public void Init(ChoosePanel view)
    {
        this.view = view;
    }

    public void OpenSystem()
    {
        Debug.Log("Work");
        view.gameObject.SetActive(true);
    }

    public void SetChoose(PersonEvent datas)
    {
        view.SetData(datas);
    }

    public void CloseSystem()
    {
        view.gameObject.SetActive(false);
    }
}

[Serializable]
public class ChooseSelectData
{
    public List<DialogData> Data = new List<DialogData>();
}