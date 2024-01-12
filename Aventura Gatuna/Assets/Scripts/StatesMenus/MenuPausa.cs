using Patterns.State.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MenuPausa : MenuState
{

    GameObject menuPausa;
    public MenuPausa(IMenu menu) : base(menu) { }

    public override void Enter()
    {
        menuPausa = menu.GetGameObject().transform.Find("MenuPausa").gameObject;
        menuPausa.SetActive(true);
    }
    public override void Exit() {
        menuPausa.SetActive(false);
    }
    public override void Update() { }
    public override void FixedUpdate() { }


}
