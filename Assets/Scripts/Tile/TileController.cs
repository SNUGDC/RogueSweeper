using UnityEngine;
using System;
using System.Collections;

namespace RogueSweeper.Tile
{
    [Serializable]
    public class TileData
    {
        public Coordinate Coordinate { get; set; }
        public bool Hidden { get; set; }
    }

    public class TileController : MonoBehaviour
    {
        public TileData data;
        public TileManager TileManager;
        public GameObject VisibleTile;
        public Action Trigger;

        void Awake()
        {
            Trigger = DefaultOnTriggered;
            Debug.Log("Awake");
        }

        public void Initialize(TileManager tileManager, TileData data)
        {
            this.TileManager = tileManager;
            this.data = data;
        }

        public void SetTileView(TileType type)
        {
            if (VisibleTile)
            {
                Destroy(VisibleTile);
            }
            var tileView = TileManager.GetTileViewObject(type);
            VisibleTile = Instantiate(tileView) as GameObject;
            VisibleTile.transform.SetParent(gameObject.transform, false);
        }

        public void DefaultOnTriggered()
        {
            Debug.Log("Triggered");
        }
    }
}