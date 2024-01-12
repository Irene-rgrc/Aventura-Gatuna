using Patterns.State.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuAjustes: MenuState
{
    GameObject menuAjustes;
    public MenuAjustes(IMenu menu) : base(menu) { }

    public override void Enter()
    {
        menuAjustes=menu.GetGameObject().transform.Find("MenuAjustes").gameObject;
        menuAjustes.SetActive(true);
    }
    public override void Exit()
    {
        menuAjustes.SetActive(false);
    }
    public override void Update() { }
    public override void FixedUpdate() { }

   
}