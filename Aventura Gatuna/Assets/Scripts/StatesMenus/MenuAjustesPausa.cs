using Patterns.State.Interfaces;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuAjustesPausa : MenuState
{
    GameObject menuAjustesPausa;
    public MenuAjustesPausa(IMenu menu) : base(menu) { }

    public override void Enter()
    {
        menuAjustesPausa = menu.GetGameObject().transform.Find("MenuAjustesEnPausa").gameObject;
        menuAjustesPausa.SetActive(true);
    }
    public override void Exit()
    {
        menuAjustesPausa.SetActive(false);
    }
    public override void Update() { }
    public override void FixedUpdate() { }


}