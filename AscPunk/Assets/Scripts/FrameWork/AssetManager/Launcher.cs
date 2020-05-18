using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using FrameWork.AssetManager;

public class Launcher : MonoBehaviour{
    public Text Content;
    public Image Img_1;
    public Button Btn_1;

    public Image Img_2;
    public Button Btn_2;


    // Use this for initialization
    void Start () {
        AssetManager.Instance.InitMode(GameConfigs.LoadAssetMode);

        Content.text = "资源管理器加载模式:" + GameConfigs.LoadAssetMode;

        Btn_1.onClick.AddListener(onClickedBtn1);
        Btn_2.onClick.AddListener(onClickedBtn2);
    }

    void onClickedBtn1() {
        SpriteAtlas atlas = AssetManager.Instance.LoadAsset<SpriteAtlas>(GameConfigs.GetSpriteAtlasPath("ui_atlas"));
        Img_1.sprite = atlas.GetSprite(string.Format("icon_{0}", Random.Range(0, atlas.spriteCount - 1)));
    }

    void onClickedBtn2() {
        AssetManager.Instance.LoadAssetAsync<SpriteAtlas>(GameConfigs.GetSpriteAtlasPath("ui_atlas"), (SpriteAtlas atlas) => {
            Img_2.sprite = atlas.GetSprite(string.Format("icon_{0}", Random.Range(0, atlas.spriteCount - 1)));
        });
    }

    
}
