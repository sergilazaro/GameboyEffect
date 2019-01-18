using UnityEngine;

public class PixelatedEffect : MonoBehaviour
{
	Material PixelMat;
	public Shader PixelShader;

	public int ZoomLevel = 4;
	public bool AddBorder = true;
	public bool UsePointFiltering = false;

	public Color ColorDarkest = new Color(.094f, .188f, .188f);
	public Color ColorDark = new Color(.314f, .471f, .408f);
	public Color ColorLight = new Color(.659f, .753f, .690f);
	public Color ColorLightest = new Color(.878f, .941f, .910f);

	private int currentWidth;
	private int currentHeight;

	void OnGUI()
	{
		if (GUI.Button(new Rect(5, 5, 150, 30), "Toggle Pixel Borders"))
		{
			AddBorder = !AddBorder;
		}
	}

	private void Awake()
	{
		PixelMat = new Material(PixelShader);

		currentWidth = Screen.width;
		currentHeight = Screen.height;
	}

	private void Update()
	{
		PixelMat.SetVector("_Sizes", new Vector4(AddBorder ? 1 : 0, ZoomLevel, Screen.width, Screen.height));

		PixelMat.SetColor("_Color_0", ColorDarkest);
		PixelMat.SetColor("_Color_1", ColorDark);
		PixelMat.SetColor("_Color_2", ColorLight);
		PixelMat.SetColor("_Color_3", ColorLightest);
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		source.filterMode = UsePointFiltering ? FilterMode.Point : FilterMode.Bilinear;
		Graphics.Blit(source, destination, PixelMat);
	}
}