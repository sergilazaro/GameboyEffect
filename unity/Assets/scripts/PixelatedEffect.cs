using UnityEngine;

public class PixelatedEffect : MonoBehaviour
{
	Texture2D RenderTexture;
	Material PixelMat;
	public Shader PixelShader;

	public int ZoomLevel = 4;
	public bool AddBorder = true;

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

	private void Awake () 
	{
		PixelMat = new Material(PixelShader);

		RenderTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		RenderTexture.filterMode = FilterMode.Bilinear;

		currentWidth = Screen.width;
		currentHeight = Screen.height;
	}

	private void Update()
	{
		PixelMat.SetTexture("_MainTex", RenderTexture);
		PixelMat.SetVector("_Sizes", new Vector4(AddBorder ? 1 : 0, ZoomLevel, Screen.width, Screen.height));

		PixelMat.SetColor("_Color_0", ColorDarkest);
		PixelMat.SetColor("_Color_1", ColorDark);
		PixelMat.SetColor("_Color_2", ColorLight);
		PixelMat.SetColor("_Color_3", ColorLightest);
	}

	private void OnPostRender()
	{
		if (currentWidth != Screen.width || currentHeight != Screen.height)
		{
			RenderTexture.Resize(Screen.width, Screen.height, TextureFormat.RGB24, false);

			currentWidth = Screen.width;
			currentHeight = Screen.height;
		}

		RenderTexture.ReadPixels(new Rect(0, 0, currentWidth, currentHeight), 0, 0);
		RenderTexture.Apply();

		GL.PushMatrix();
		{
			PixelMat.SetPass(0);
			GL.LoadOrtho();
			GL.Begin(GL.QUADS);
			{
				GL.MultiTexCoord(0, new Vector3(0, 0, 0));
				GL.Vertex3(0, 0, 0);
				GL.MultiTexCoord(0, new Vector3(0, 1, 0));
				GL.Vertex3(0, 1, 0);
				GL.MultiTexCoord(0, new Vector3(1, 1, 0));
				GL.Vertex3(1, 1, 0);
				GL.MultiTexCoord(0, new Vector3(1, 0, 0));
				GL.Vertex3(1, 0, 0);
			}
			GL.End();
		}
		GL.PopMatrix();
	}

}