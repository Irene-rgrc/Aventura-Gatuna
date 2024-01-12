using Patterns.State.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creditos : MenuState
{
    GameObject menuCreditos;
    public Creditos(IMenu menu) : base(menu) { }

    public override void Enter()
    {
        menuCreditos = menu.GetGameObject().transform.Find("Creditos").gameObject;
        menuCreditos.SetActive(true);
    }
    public override void Exit()
    {
        menuCreditos.SetActive(false);
    }
    public override void Update() { }
    public override void FixedUpdate() { }


}