using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

namespace RogueSweeper
{
    using Tile;
    public class TileManager : MonoBehaviour
    {
        public GameObject TileFlag;
        public GameObject TileMine;
        public GameObject TileHidden;
        public GameObject[] TileNumbers;

        public GameObject TileBase;

        private Dictionary<Coordinate, TileController> tileControllersOnBoard = new Dictionary<Coordinate, TileController>();

        public void Start()
        {
            CreateTile(new Coordinate(0, 0));
            CreateTile(new Coordinate(1, 0));
            CreateTile(new Coordinate(2, 0));
            CreateTile(new Coordinate(3, 0));
        }

        public GameObject GetTileViewObject(TileType type)
        {
            switch (type.Category)
            {
                case TileCategory.HIDDEN:
                    return TileHidden;
                case TileCategory.FLAG:
                    return TileFlag;
                case TileCategory.MINE:
                    return TileMine;
                case TileCategory.NUMBER:
                    return TileNumbers[type.Number];
                default:
                    return null;
            }
        }

        public TileController GetTileAt(Coordinate coordinate)
        {
            if(tileControllersOnBoard.ContainsKey(coordinate)){
                return tileControllersOnBoard[coordinate];
            } else {
                return null;
            }
        }

        public GameObject CreateTile(Coordinate coord)
        {
            var newTile = Instantiate(TileBase, Vector3.zero, Quaternion.identity) as GameObject;
            
            var tileTransform = newTile.transform;
            tileTransform.SetParent(gameObject.transform, false);
            tileTransform.position = new Vector3(coord.x, coord.y, 0);

            var tileController = newTile.GetComponent<TileController>();
            tileController.Initialize(this, new TileData
            {
                Coordinate = coord,
                Hidden = true,
            });
            tileController.SetTileView(new TileType(TileCategory.HIDDEN));
            tileControllersOnBoard.Add(coord, tileController);

            return newTile;
        }
    }
}