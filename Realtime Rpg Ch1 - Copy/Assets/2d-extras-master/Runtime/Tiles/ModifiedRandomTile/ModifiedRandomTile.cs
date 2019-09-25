using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityEngine.Tilemaps 
{
    //Made By Rayan Talih
    //Email - Ryantalih@gmail.com

    /// <summary>
    /// A Sprite with a Weight value for randomization.
    /// </summary>
    [Serializable]
    public struct modifiedWeightedSprite 
    {
        /// <summary>
        /// Sprite.
        /// </summary>
        public Sprite Sprite;
        /// <summary>
        /// Weight of the Sprite.
        /// </summary>
        [Range(1f,100f)]
        public float Weight;
    }

    /// <summary>

    /// <summary>
    /// Weighted First Random Tiles are tiles which provide a percentage weight for selecting your main sprite, and randomly select a sprite a given list of alternative sprites that will 
    /// be picked randomly if the main tile's percent chance isn't hit. This is great for painting grass and a variety of grass among a widespread area.
    /// </summary>
    [Serializable]
    [CreateAssetMenu(fileName = "New Weighted First RandomTile", menuName = "Tiles/Weighted First Random Tile")]
    public class ModifiedRandomTile : Tile 
    {
        /// <summary>
        /// The Sprites used for randomizing output.
        /// </summary>
        [SerializeField] public modifiedWeightedSprite[] Sprites;

        [SerializeField] public Sprite[] SpritesExtra;

        /// <summary>
        /// Retrieves any tile rendering data from the scripted tile.
        /// </summary>
        /// <param name="position">Position of the Tile on the Tilemap.</param>
        /// <param name="tilemap">The Tilemap the tile is present on.</param>
        /// <param name="tileData">Data to render the tile.</param>
        public override void GetTileData(Vector3Int location, ITilemap tileMap, ref TileData tileData) 
        {
            base.GetTileData(location, tileMap, ref tileData);
            
            if (Sprites == null || Sprites.Length <= 0) return;
            
            long hash = location.x;
            hash = hash + 0xabcd1234 + (hash << 15);
            hash = hash + 0x0987efab ^ (hash >> 11);
            hash ^= location.y;
            hash = hash + 0x46ac12fd + (hash << 7);
            hash = hash + 0xbe9730af ^ (hash << 11);
            Random.InitState((int) hash);

            // Get the cumulative weight of the sprites
            var cumulativeWeight = Sprites[0].Weight;
      //      foreach (var spriteInfo in Sprites) cumulativeWeight += spriteInfo.Weight;

            // Pick a random weight and choose a sprite depending on it
          //  if (Random.value * 100f < Sprites[0].Weight)
          if(Random.Range(0,100f)< Sprites[0].Weight)
            {
                tileData.sprite = Sprites[0].Sprite;
            }
            else
            {
                if (SpritesExtra.Length > 0)
                    tileData.sprite = SpritesExtra[Random.Range(0, SpritesExtra.Length)];
                else
                    tileData.sprite = Sprites[0].Sprite;
            }

        /*    foreach (var spriteInfo in Sprites) {
                randomWeight -= spriteInfo.Weight;
                if (randomWeight < 0) {
                    tileData.sprite = spriteInfo.Sprite;    
                    break;
                }
            }*/
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(ModifiedRandomTile))]
    public class ModifiedRandomTileEditor : Editor 
    {
        private SerializedProperty m_Color;
        private SerializedProperty m_ColliderType;

        private ModifiedRandomTile Tile {
            get { return target as ModifiedRandomTile; }
        }

        public void OnEnable()
        {
            m_Color = serializedObject.FindProperty("m_Color");
            m_ColliderType = serializedObject.FindProperty("m_ColliderType");
        }

        public override void OnInspectorGUI() 
        {
            serializedObject.Update();

            EditorGUI.BeginChangeCheck();

            int count = EditorGUILayout.DelayedIntField("Main Sprite", 1);
            if (count < 0) 
                count = 0;

          /*  if (Tile.Sprites == null || Tile.Sprites.Length != count) 
            {
                Array.Resize(ref Tile.Sprites, count);
            }*/

            if (count == 0) 
                return;

            EditorGUILayout.LabelField("Place main sprite.");
            EditorGUILayout.Space();

            for (int i = 0; i < 1; i++) 
            {
                Tile.Sprites[i].Sprite = (Sprite) EditorGUILayout.ObjectField("Sprite " + (i + 1), Tile.Sprites[i].Sprite, typeof(Sprite), false, null);

                EditorGUILayout.Space();

                EditorGUILayout.LabelField("Percent Chance");

                Tile.Sprites[i].Weight = EditorGUILayout.Slider(Tile.Sprites[i].Weight, 1f, 100f);
            }

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(m_Color);
            EditorGUILayout.PropertyField(m_ColliderType);

            /*    if (EditorGUI.EndChangeCheck())
                {
                    EditorUtility.SetDirty(Tile);
                    serializedObject.ApplyModifiedProperties();
                }*/

            //     serializedObject.Update();

            //  EditorGUI.BeginChangeCheck();

            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();

            int counter = EditorGUILayout.DelayedIntField("Alternative Sprites", Tile.SpritesExtra != null ? Tile.SpritesExtra.Length : 0);
            if (counter < 0) 
                counter = 0;

            if (Tile.SpritesExtra == null || Tile.SpritesExtra.Length != counter) 
            {
                Array.Resize(ref Tile.SpritesExtra, counter);
            }

            if (counter == 0) 
                return;

            EditorGUILayout.LabelField("Place alternative sprites.");
            EditorGUILayout.Space();

            for (int i = 0; i < counter; i++) 
            {
                Tile.SpritesExtra[i] = (Sprite) EditorGUILayout.ObjectField("Sprite " + (i + 1), Tile.SpritesExtra[i], typeof(Sprite), false, null);
           //     Tile.SpritesExtra[i].Weight = EditorGUILayout.IntField("Weight " + (i + 1), Tile.SpritesExtra[i].Weight);
            }

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(m_Color);
            EditorGUILayout.PropertyField(m_ColliderType);

            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(Tile);
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
#endif
}
