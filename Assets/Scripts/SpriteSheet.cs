using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteSheet", menuName = "Custom/SpriteSheet")]
public class SpriteSheet : ScriptableObject
{
	public Texture2D baseTexture;
	[SerializeField] int columns, rows;
    public Sprite[] sprites;

	public Sprite GetSprite(int x, int y)
	{
		x = Mathf.Clamp(x, 0, columns-1);
		y = Mathf.Clamp(y, 0, rows-1);
		return sprites[y + rows*x];
	}

	[ContextMenu("Slice Sprites")]
	void SliceSprites()
	{
		string path = AssetDatabase.GetAssetPath(baseTexture);

		TextureImporter ti = AssetImporter.GetAtPath(path) as TextureImporter;
		ti.isReadable = true;

		List<SpriteMetaData> newData = new List<SpriteMetaData>();

		int width = baseTexture.width / columns;
		int height = baseTexture.height / rows;

		for (int y = 0; y < rows; y++)
		{
			for (int x = 0; x < columns; x++)
			{
				SpriteMetaData smd = new SpriteMetaData();

				smd.pivot = new Vector2(0.5f, 0.5f);
				smd.alignment = 9;
				smd.name = $"{baseTexture.name}_({x},{y})";
				smd.rect =  new Rect(x * width, (rows-1-y) * height, width, height);

				newData.Add(smd);
			}
		}
		ti.spritesheet = newData.ToArray();
		ti.spriteImportMode = SpriteImportMode.Multiple;
		AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
		sprites = AssetDatabase.LoadAllAssetsAtPath(path).OfType<Sprite>().ToArray();

		string assetPath = AssetDatabase.GetAssetPath(GetInstanceID());
		AssetDatabase.RenameAsset(assetPath, baseTexture.name);
		AssetDatabase.SaveAssets();
	}
}
