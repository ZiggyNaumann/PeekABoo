using System;
using UnityEngine;

namespace PeekABoo.Clues
{
    [Serializable]
    public class ClueConfig
    {
        [SerializeField] private string name;
        [SerializeField] private Sprite sprite;
        [SerializeField] private Clue cluePrefab;
        // TODO: Add reference to Painting

        public string Name => name;
        public Sprite Sprite => sprite;
        public Clue CluePrefab => cluePrefab;
    }
}
