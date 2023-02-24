using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoiseSettings
{
    public enum Filtertype
    {
        Simple,
        Ridgid
    };
    public Filtertype filterType;
    
    [ConditionalHide("filterType", 0)]
    public SimpleNoiseSettings simpleNoiseSettings;
    [ConditionalHide("filterType", 1)]
    public RigdidNoiseSettings rigdidNoiseSettings;

    [System.Serializable]
    public class SimpleNoiseSettings
    {
        public float strength = 1;
        [Range(1, 8)] public int numLayers = 1;
        public float baseRoughness = 1;
        public float roughness = 1;
        public float persistance = .5f;
        public Vector3 centre;
        public float minValue; 
    }

    [System.Serializable]
    public class RigdidNoiseSettings : SimpleNoiseSettings
    {
        public float weightMultiplier = .8f;
    }
}
