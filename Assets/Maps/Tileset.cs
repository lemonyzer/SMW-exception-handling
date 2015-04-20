﻿using UnityEngine;
//using UnityEditor;
using System.Collections;
//using System.Collections.Generic;


[System.Serializable]
public class Tileset : ScriptableObject {

//	[SerializeField]
//	private Texture tilesetTexture;
//	[SerializeField]
//	private Texture2D tilesetTexture2D;
//	[SerializeField]
//	private GUITexture tilesetGUITexture;

//	[SerializeField]
//	public SpriteMetaData[] spriteMetaData;
//	[SerializeField]
//	public Sprite[] tilesetArray;

	[SerializeField]
	public string tilesetName;
	[SerializeField]
	private Sprite tileset;
	[SerializeField]
	private int width;
	[SerializeField]
	private int height;
	[SerializeField]
	float tileWidth = 32;
	[SerializeField]
	float tileHeight = 32;
	[SerializeField]
	public Vector2 tilePivot;

	public Sprite TilesetSprite {
		get {
			return this.tileset;
		}
		set {
			tileset = value;
			width = tileset.texture.width;
			height = tileset.texture.height;
		}
	}

	public int Width {
		get {
			return this.width;
		}
		private set {
			width = value;
		}
	}

	public int Height {
		get {
			return this.height;
		}
		private set {
			height = value;
		}
	}

	public Vector2 TilePivot {
		get {
			return this.tilePivot;
		}
		set {
			tilePivot = value;
		}
	}

	short iWidth, iHeight;
	short iTileTypeSize;
	TileType[] tiletypes;

	public Sprite GetNewCreatetTileSprite(int x, int y)
	{
		if(tileset == null)
		{
			Debug.LogError ("Tiletset has no tileset Sprite!");
			return null;
		}
		Texture2D tilesetTexture = tileset.texture;

		float tilesetWidth = tilesetTexture.width;
		float tilesetHeight = tilesetTexture.height;


		// check if x, y out of Texture Bounds

		int xMax = Mathf.FloorToInt(tilesetWidth/tileWidth) -1 ;
//		Debug.Log("xMax = " + xMax);
		if(x < 0 || x > xMax)
		{
			Debug.LogError("x = " + x + " out of bounds, xMin=0 & xMax=" + xMax);
			return null;
		}

		int yMax = Mathf.FloorToInt(tilesetHeight/tileHeight) -1 ;
//		Debug.Log("yMax = " + yMax);
		if(y < 0 || y > yMax)
		{
			Debug.LogError("y = " + y + " out of bounds, yMin=0 & yMax=" + yMax);
			return null;
		}

		// transform texture bottom, left to top, left
//		textureX = tilesetWidth - x*tileWidth;
		float textureX = x * tileWidth;
		float textureY = tilesetHeight - (y+1)*tileHeight;			// Tile TileBottomLeft Position + Rect
//		int textureY = tilesetHeight/tileHeight - y;

//		int tileTextureX = textureX * tileWidth;
//		int tileTextureY = textureY * tileHeight;

		Rect subSpriteRect = new Rect(textureX,
		                              textureY,
		                              tileWidth,
		                              tileHeight);

		float pixelPerUnit = tileset.pixelsPerUnit;

		Sprite subSprite = Sprite.Create(tilesetTexture, subSpriteRect, tilePivot, pixelPerUnit);		// erzeugt neues Sprite (ohne Verbindung zu spliced Asset)

		return subSprite;
	}

#if UNITY_EDITOR
	public Sprite GetTileSprite(int x, int y)
	{
		string assetRelativPath = UnityEditor.AssetDatabase.GetAssetPath(tileset);
		UnityEngine.Object[] assets = UnityEditor.AssetDatabase.LoadAllAssetsAtPath(assetRelativPath);			// TODO store this array in ScriptableObject, doesnt need to load it for every Tile of the map

		int subSpritePos = x + y*Mathf.FloorToInt(width/tileWidth);
		subSpritePos++;	// root Asset is no SubSprite (sliced Sprite)
		if(subSpritePos > assets.Length)
		{
			Debug.LogError("Sub Sprite Pos " + subSpritePos + " > " + assets.Length + " Tileset Array Length");
		}
		else
		{
//			Debug.Log("Sub Sprite Pos " + subSpritePos + ", Tileset Array Length" + assets.Length);
			Sprite sprite = new Sprite();
			sprite = assets[subSpritePos] as Sprite;
			return sprite;
//			return (Sprite) assets[subSpritePos];
//			return assets[subSpritePos] as Sprite;
		}
		return null;
	}
#endif
	public void OnEnable()
	{
		Debug.Log(this.ToString() + " OnEnable()");
		if(tilePivot == null)
		{
			Debug.LogWarning("tilePivot not set, set default Value!");
			tilePivot = new Vector2 (0f,0f);
		}

	}

	public TileType GetTileType(short iTileCol, short iTileRow)
	{
		return tiletypes[iTileCol + iTileRow * iWidth];
	}

	void SetTileType(short iTileCol, short iTileRow, TileType type)
	{
		tiletypes[iTileCol + iTileRow * iWidth] = type;
	}

	public TileType IncrementTileType(short iTileCol, short iTileRow)
	{
		short iTile =((short)((int) iTileCol + (int) iTileRow * (int) iWidth));
		tiletypes[iTile] = GetIncrementedTileType(tiletypes[iTile]);
		
		return tiletypes[iTile];
	}

	public TileType GetIncrementedTileType(TileType type)
	{
		if(type == TileType.tile_nonsolid)
			return TileType.tile_solid;
		else if(type == TileType.tile_solid)
			return TileType.tile_solid_on_top;
		else if(type == TileType.tile_solid_on_top)
			return TileType.tile_ice;
		else if(type == TileType.tile_ice)
			return TileType.tile_death;
		else if(type == TileType.tile_death)
			return TileType.tile_death_on_top;
		else if(type == TileType.tile_death_on_top)
			return TileType.tile_death_on_bottom;
		else if(type == TileType.tile_death_on_bottom)
			return TileType.tile_death_on_left;
		else if(type == TileType.tile_death_on_left)
			return TileType.tile_death_on_right;
		else if(type == TileType.tile_death_on_right)
			return TileType.tile_ice_on_top;
		else if(type == TileType.tile_ice_on_top)
			return TileType.tile_ice_death_on_bottom;
		else if(type == TileType.tile_ice_death_on_bottom)
			return TileType.tile_ice_death_on_left;
		else if(type == TileType.tile_ice_death_on_left)
			return TileType.tile_ice_death_on_right;
		else if(type == TileType.tile_ice_death_on_right)
			return TileType.tile_super_death;
		else if(type == TileType.tile_super_death)
			return TileType.tile_super_death_top;
		else if(type == TileType.tile_super_death_top)
			return TileType.tile_super_death_bottom;
		else if(type == TileType.tile_super_death_bottom)
			return TileType.tile_super_death_left;
		else if(type == TileType.tile_super_death_left)
			return TileType.tile_super_death_right;
		else if(type == TileType.tile_super_death_right)
			return TileType.tile_player_death;
		else if(type == TileType.tile_player_death)
			return TileType.tile_nonsolid;
		
		return TileType.tile_nonsolid;
	}
	
//	public string Name {
//		get {
//			return this.tilesetName;
//		}
//		set {
//			tilesetName = value;
//		}
//	}
//	
//	public int Height {
//		get {
//			return this.height;
//		}
//		set {
//			height = value;
//		}
//	}
//	
//	public int Width {
//		get {
//			return this.width;
//		}
//		set {
//			width = value;
//		}
//	}
	
}
