using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using System;
using Random = UnityEngine.Random;

public class SphereBehaviour : EntityEventListener<ISphereState>
{
    Renderer _renderer;
    public Color color;
    public override void Attached()
    {
        _renderer = GetComponent<Renderer>();

        state.SetTransforms(state.SphereTransform, transform);

        if (entity.IsOwner)
        {
            state.MaterialColor = PocAppSettings.SphereColor;
        }

        state.AddCallback("MaterialColor", ColorChanged);
    }

    private void ColorChanged()
    {
        _renderer.material.color = state.MaterialColor;
    }
}
